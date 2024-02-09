using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using worknet_api.Data;

namespace worknet_api.Controllers
{
    [Route("api/Location/[action]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ApiContext _context;

        public LocationController(ApiContext apiContext)
        {
            _context = apiContext;
        }

        [HttpGet]
        public JsonResult GetAll()
        {

            var locations = _context.Locations.ToList();

            if (locations.Count() != 0)
            {

                return new JsonResult(new
                {
                    success = true,
                    data = locations,
                });
            }
            else
            {
                return new JsonResult(new
                {
                    success = false,
                    message = "No locations."
                });
            }

        }
    }
}
