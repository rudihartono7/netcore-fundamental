using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppKaryawan.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppKaryawan.Controllers
{
    [Route("api/[controller]")]
    public class CompanyAPIController : Controller
    {
        private readonly CompanyContext _context;

        public CompanyAPIController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            return await _context.Company.ToListAsync();
        }

        // GET: api/employee/1
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
    }
}
