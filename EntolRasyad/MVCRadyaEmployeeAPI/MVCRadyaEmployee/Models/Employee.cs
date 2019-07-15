using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRadyaEmployee.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Position { get; set; }
        public int CompanyID { get; set; }
    }
}
