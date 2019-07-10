using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelloRadyaWebMVC.Data
{
    public enum EmployeePosition { WEB, ANDROID, DESIGNER, PM, ANALYST, TESTER }

    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Position { get; set; }
        [Required]
        public EmployeePosition PositionEnum { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("Company")]
        public string CompanyID { get; set; }

        public virtual Company Company { get; set; }
    }
}
