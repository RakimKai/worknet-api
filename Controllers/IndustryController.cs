using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using worknet_api.Data;

namespace worknet_api.Controllers
{
    [Route("api/Industry/[action]")]
    [ApiController]
    public class IndustryController : ControllerBase
    {
        ApiContext _context;
        public IndustryController(ApiContext apiContext)
        {
            _context= apiContext;
        }
        [HttpGet]

        public JsonResult GetAll()
        {

            var industries = _context.Industries.ToList();

            if (industries.Count() != 0)
            {

                return new JsonResult(new
                {
                    success = true,
                    data = industries,
                });
            }
            else
            {
                return new JsonResult(new
                {
                    success = false,
                    message = "No industries."
                });
            }

        }
    }
}
