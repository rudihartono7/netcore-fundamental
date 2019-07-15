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
    public class CmpController : Controller
    {
        private readonly CompanyContext _context;

        public CmpController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompany()
        {
            return await _context.Company.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{CompanyID}")]
        public async Task<ActionResult<Company>> GetCompany(int CompanyID)
        {
            var companyItem = await _context.Company.FindAsync(CompanyID);

            if (companyItem == null)
            {
                return NotFound();
            }

            return companyItem;
        }
    }
}