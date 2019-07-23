using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAppKaryawan.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext (DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppKaryawan.Models.Employee> Employee { get; set; }
        public DbSet<WebAppKaryawan.Models.Company> Company { get; set; }
    }
}
