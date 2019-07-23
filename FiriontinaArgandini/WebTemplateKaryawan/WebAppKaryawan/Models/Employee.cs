using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppKaryawan.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(30)]
        [Required]
        public string Position { get; set; }

        public int CompanyID { get; set; }
    }
}
