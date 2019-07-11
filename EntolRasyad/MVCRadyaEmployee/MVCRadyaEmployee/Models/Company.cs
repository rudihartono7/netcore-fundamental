using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRadyaEmployee.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Employee> Team { get; set; }
    }
}
