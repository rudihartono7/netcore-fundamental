using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppKaryawan.Models
{
    public class Company
    {
        public int CompanyID { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [Required]
        public string Address { get; set; }
    }
}
