using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using worknet_api.Data;
using worknet_api.Helpers.Services;
using worknet_api.Models;
using worknet_api.ViewModels;

namespace worknet_api.Controllers
{
    [Route("api/Review/[action]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly ApiContext _context;


        public ReviewsController(ApiContext apiContext,AuthService authService)
        {
            _context = apiContext;
            _authService = authService;
        }
        [HttpPost]
        public JsonResult Create([FromBody] ReviewCreateVM review)
        {
            var token = _authService.GetInfo().Token;
            var employee = (Employee) _authService.GetInfo().KorisnickiNalog;
            var company = _context.Companies.Where(x => x.Id == review.CompanyId).FirstOrDefault();
            if (token == null)
            {
                return new JsonResult( BadRequest());
            }
            var newReview = new Review
            {
                Employee = employee,
                Company = company,
                Rating = review.Rating,
                Title = review.Title,
                Content = review.Content
            };
            employee.Reviews.Add(newReview);
            company.Reviews.Add(newReview);
            _context.Reviews.Add(newReview);
            _context.SaveChanges();
            return new JsonResult(new
            {
                data = newReview
            });
        }

        [HttpGet]
        public JsonResult Get(int Id)
        {
            var review = _context.Reviews.Include(x=>x.Company.Location).Include(x=>x.Company.Posts).Include(x=>x.Employee.Location).FirstOrDefault(x => x.Id == Id);
            if (review == null)
            {
                return new JsonResult(BadRequest());
            }
            return new JsonResult(new
            {
                data = review
            });
        }


        [HttpGet]
        public JsonResult GetAll()
        {
            var reviews = _context.Reviews.Include(x => x.Company.Location).Include(x=>x.Company.Posts).Include(x => x.Employee.Location).ToList();
            if (reviews.Count() != 0)
            {

                return new JsonResult(new
                {
                    data = reviews
                });
            }
            else return new JsonResult(new
            {
                message="No reviews"
            });
        }

        [HttpDelete]
        public JsonResult Delete(int Id)
        {
            var review = _context.Reviews.FirstOrDefault(x => x.Id == Id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                _context.SaveChanges();
                return new JsonResult(new
                {
                    message = "Review was successfully deleted."
                });
            }
            else
            {
            return new JsonResult(BadRequest());
            }
        }

        [HttpPut]
        public JsonResult Edit(int Id, [FromBody]ReviewEditVM review)
        {
            var reviewInDb = _context.Reviews.FirstOrDefault(x => x.Id == Id);
            if (reviewInDb != null)
            {
                reviewInDb.Title = review.Title;
                reviewInDb.Content = review.Content;
                reviewInDb.Rating = review.Rating;
                _context.Update(reviewInDb);
                _context.SaveChanges();
                return new JsonResult(new
                {
                    data = reviewInDb
                });
            }
            else
            {
                return new JsonResult(BadRequest());
            }
        }
    }
}
