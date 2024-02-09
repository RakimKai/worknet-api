using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using worknet_api.Data;
using worknet_api.Helpers.Services;
using worknet_api.Models;

namespace worknet_api.Controllers
{
    [Route("api/Skill/[action]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly AuthService _authService;
        public SkillController(ApiContext apiContext, AuthService authService)
        {
            _context= apiContext;
            _authService= authService;
        }

        [HttpPost]
        public JsonResult Create([FromBody] string[] skills)
        {
            var employee = (Employee)_authService.GetInfo().KorisnickiNalog;

            if (employee == null)
                return new JsonResult(BadRequest());

            foreach (var skill in skills)
                if (!skill.IsNullOrEmpty())
                    employee.Skills.Add(skill);

            _context.Employees.Update(employee);
            _context.SaveChanges();
            return new JsonResult(Ok());
        }

        [HttpDelete]
        public JsonResult Delete([FromQuery] string skill)
        {
            var employee = (Employee)_authService.GetInfo().KorisnickiNalog;
            employee.Skills.Remove(skill);
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return new JsonResult(Ok());
        }

    }
}
