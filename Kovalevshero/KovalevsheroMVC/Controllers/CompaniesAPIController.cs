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
    public class CompaniesAPIController : ControllerBase
    {
        private readonly KovalevsheroMVCContext _context;

        public CompaniesAPIController(KovalevsheroMVCContext context)
        {
            _context = context;

            if (_context.Company.Count() == 0)
            {
                _context.Company.Add(new Company { CompanyID = 1, Name = "Corporation", Address = "Avenue" });
                _context.SaveChanges();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostTodoItem(Company company)
        {

            _context.Company.Add(company);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCompany), new { id = company.CompanyID }, company);

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            return await _context.Company.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var todoItem = await _context.Company.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, Company item)
        {
            if (id != item.CompanyID)
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
            var todoItem = await _context.Company.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Company.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
