using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVCRadyaEmployee.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext (DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<MVCRadyaEmployee.Models.Employee> Employee { get; set; }
        public DbSet<MVCRadyaEmployee.Models.Company> Company { get; set; }
    }
}
