using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCRadyaEmployee.Models;

namespace MVCRadyaEmployee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : Controller
    {
        private readonly EmployeeContext _context;

        public EmpController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.Employee.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{EmployeeID}")]
        public async Task<ActionResult<Employee>> GetEmployee(int EmployeeID)
        {
            var employeeItem = await _context.Employee.FindAsync(EmployeeID);

            if (employeeItem == null)
            {
                return NotFound();
            }

            return employeeItem;
        }
    }
}