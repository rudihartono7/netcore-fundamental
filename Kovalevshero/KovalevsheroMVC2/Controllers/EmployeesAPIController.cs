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
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Employee.Add(new Employee { Id = 1, Name = "Levs", Position = "Master", CompanyID = 1 });
                _context.SaveChanges();
            }
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetTodoItems()
        {
            return await _context.Employee.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetTodoItem(int id)
        {
            var todoItem = await _context.Employee.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }


    }
}
