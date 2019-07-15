using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KovalevsheroMVC.Models;

namespace KovalevsheroMVC.Models
{
    public class KovalevsheroMVCContext : DbContext
    {
        public KovalevsheroMVCContext (DbContextOptions<KovalevsheroMVCContext> options)
            : base(options)
        {
        }

        public DbSet<KovalevsheroMVC.Models.Employee> Employee { get; set; }

        public DbSet<KovalevsheroMVC.Models.Company> Company { get; set; }
    }
}
