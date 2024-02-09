using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using worknet_api.Data;
using worknet_api.Helpers.Services;
using worknet_api.Models;
using worknet_api.ViewModels;

namespace worknet_api.Controllers
{
    [Route("api/Post/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly ApiContext _context;
        private readonly AuthService _authService;
        public PostController(ApiContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost]
        public JsonResult Create([FromBody] PostCreateVM post)
        {
            Token token = _authService.GetInfo().Token;
            if (token == null)
            {
                return new JsonResult(new { message = "You're not logged in." });
            }
            var location = _context.Locations.FirstOrDefault(l => l.Id == post.Location.Id);
            var employmentType = _context.EmploymentTypes.FirstOrDefault(e => e.Id == post.EmploymentType.Id);
            var industry = _context.Industries.FirstOrDefault(i => i.Id == post.Industry.Id);

            var newPost = new Post
            {
                Company = (Company)_authService.GetInfo().KorisnickiNalog,
                Date = post.Date,
                Title = post.Title,
                Content=post.Content,
                Location = location,
                EmploymentType = employmentType,
                Industry=industry
            };
            _context.Posts.Add(newPost);
            _context.SaveChanges();
            return new JsonResult(new
            {
                success = true,
                data = newPost
            });

        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var post = _context.Posts
                .Include(p=>p.Company)
                .Include(p=>p.Location)
                .Include(p => p.Industry)
                .Include(p => p.EmploymentType)
                .FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return BadRequest(new { message = "Post doesn't exist" });
            }
            else return Ok(new { data = post });
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var posts = _context.Posts
                .Include(p=>p.Company.Location).Include(p=>p.Industry)
                .Include(p=>p.EmploymentType).Include(p=>p.Location).ToList();

            if (posts.Count == 0)
            {
                return new JsonResult(new
                {
                    success = false,
                    message = "There aren't any posts."
                });
            }
            return new JsonResult(new
            {
                success = true,
                data = posts
            });
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var post = _context.Posts.Find(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
                return new JsonResult(new
                {
                    success = true,
                    message = "Post successfully deleted."
                });
            }
            else
            {
                return new JsonResult(new
                {
                    success = false,
                    message = "Post doesn't exist."
                });

            }
        }
        [HttpPut]
        public JsonResult Edit(int Id, [FromBody] PostEditVM post)
        {
            var postInDb = _context.Posts.FirstOrDefault(x=>x.Id==Id);

            if (postInDb == null)
            {
                return new JsonResult(BadRequest("Post doesn't exist."));
            }
            postInDb.Content = post.Content;
            postInDb.Title = post.Title;
            postInDb.Date=post.Date;
            var location = _context.Locations.Find(post.LocationId);
            postInDb.Location = location == null ? postInDb.Location : location;
            _context.Posts.Update(postInDb);
            _context.SaveChanges();
            return new JsonResult(new
            {
                data = postInDb,
            });

        }

        [HttpPost]
        public IActionResult TopPostCounter(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null)
            {
                return BadRequest();
            }
            post.Views++;
            _context.Posts.Update(post);
            _context.SaveChanges();
            return Ok(); 
        }

        [HttpGet]
        public IActionResult TopPosts()
        {
            var posts = _context.Posts
                .Include(p=>p.Company.Location)
                .Include(p=>p.EmploymentType)
                .Include(p=>p.Location)
                .Include(p=>p.Industry)
                .OrderByDescending(p => p.Views).Take(3).ToList();
            return Ok(new { posts });
        }


        [HttpPost]
        public ActionResult<List<Post>> Search([FromBody] SearchVM searchObj)
        {
            int totalPosts = _context.Posts.Count();
            int totalPages = totalPosts == 0 || searchObj.PerPage == 0 ? 1 : (int)Math.Ceiling((decimal)totalPosts / searchObj.PerPage);
            searchObj.Page = searchObj.Page == 0 ? 1 : searchObj.Page;
            
            var data = _context.Posts
                .Include(p => p.Company.Location)
                .Include(p => p.EmploymentType)
                .Include(p => p.Location)
                .Include(p => p.Industry)
                .Where(x => searchObj.JobTitle == null || x.Title.Contains(searchObj.JobTitle))
                .Where(x => searchObj.Company == null || x.Company.CompanyName.Contains(searchObj.Company))
                .Where(x => searchObj.Industry == null || x.Industry.Name.Contains(searchObj.Industry))
                .Where(x => searchObj.Location == null || x.Location.City.Contains(searchObj.Location))
                .Where(x => searchObj.EmploymentType == null || x.EmploymentType.Title.Contains(searchObj.EmploymentType)).ToList();
            
            if (searchObj.Popular)
            {
                return Ok(new { data = data.OrderByDescending(x => x.Views).Skip((searchObj.Page - 1) * searchObj.PerPage).Take(searchObj.PerPage), totalPages });
            }
            return Ok(new { data = data.OrderByDescending(p => p.Id).Skip((searchObj.Page - 1) * searchObj.PerPage).Take(searchObj.PerPage), totalPages });
        }
    }
}
