using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KovalevsheroMVC.Models
{
    public class Company
    {
        [Required]
        public int CompanyID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
