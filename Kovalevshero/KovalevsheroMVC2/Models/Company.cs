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
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
