using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KovalevsheroWebAPI.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int CompanyID { get; set; }
    }
}
