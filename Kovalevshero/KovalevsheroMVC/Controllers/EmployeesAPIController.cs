using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KovalevsheroMVC.Models;

namespace KovalevsheroMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesAPIController : ControllerBase
    {
        private readonly KovalevsheroMVCContext _context;

        public EmployeesAPIController(KovalevsheroMVCContext context)
        {
            _context = context;

            if (_context.Employee.Count() == 0)
            {
                _context.Employee.Add(new Employee { Id = 1, Name = "Levs", Position = "Master", CompanyID = 1 });
                _context.SaveChanges();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostTodoItem(Employee employee)
        {
                _context.Employee.Add(employee);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employee.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var todoItem = await _context.Employee.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, Employee item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var todoItem = await _context.Employee.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
