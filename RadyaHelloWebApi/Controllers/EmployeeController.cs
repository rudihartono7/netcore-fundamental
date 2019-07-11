using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadyaHelloWebApi.Models;

namespace RadyaHelloWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET api/employee
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeViewModel>> Get()
        {
            return new JsonResult(GetEmployees());
        }

        [HttpPost]
        public ActionResult Post(EmployeeViewModel model)
        {

            return new JsonResult(model);
        }

        [HttpGet("get_server_time")]
        public IActionResult GetServerTime()
        {
            return new JsonResult(new { date = DateTime.Now });
        }

        private IEnumerable<EmployeeViewModel> GetEmployees()
        {
            yield return new EmployeeViewModel { Id = 1, Name = "Rudi", Position = "Web Developer" };
            yield return new EmployeeViewModel { Id = 2, Name = "Hegi", Position = "Web Developer" };
            yield return new EmployeeViewModel { Id = 3, Name = "Yunus", Position = "Web Developer" };
            yield return new EmployeeViewModel { Id = 4, Name = "Ade", Position = "Web Developer" };
            yield return new EmployeeViewModel { Id = 5, Name = "Asep", Position = "Web Developer" };
        }
    }
}