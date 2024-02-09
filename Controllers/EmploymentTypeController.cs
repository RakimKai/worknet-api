using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using worknet_api.Data;

namespace worknet_api.Controllers
{
    [Route("api/EmploymentType/[action]")]
    [ApiController]
    public class EmploymentTypeController : ControllerBase
    {
        ApiContext _context;
        public EmploymentTypeController(ApiContext apiContext)
        {
            _context = apiContext;
        }

        [HttpGet]
        public JsonResult GetAll()
        {

            var types = _context.EmploymentTypes.ToList();

            if (types.Count != 0)
            {

                return new JsonResult(new
                {
                    success = true,
                    data = types,
                });
            }
            else
            {
                return new JsonResult(new
                {
                    success = BadRequest(),
                    message = "No employment types."
                });
            }

        }

    }
}
