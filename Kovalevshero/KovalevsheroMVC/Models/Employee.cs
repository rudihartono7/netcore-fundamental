using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KovalevsheroMVC.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Position { get; set; }

        public int CompanyID { get; set; }
    }
}
