using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelloRadyaWebMVC.Data
{
    public class Company
    {
        [Key]
        public string CompanyID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Addresss { get; set; }
        public bool IsActive { get; set; }
    }
}
