using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloRadyaWebMVC.Data
{
    public class CompanyDbContext: DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options):
            base(options: options)
        {
            
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
