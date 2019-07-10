using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloRadyaWebMVC.Models
{
    public class EmployeeFilterViewModel
    {
        public EmployeePosition employeePosition { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string keyword { get; set; }
    }
    public enum EmployeePosition { WEB, ANDROID }
    public class EmployeeViewModel
    {
        [Required(ErrorMessage = "ID harus di isi dong")]
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Yang namanya kurang tiga huruf gak boleh masuk RL" )]
        public string Name { get; set; }
        public string Position { get; set; }
        [Required]
        public EmployeePosition PositionEnum { get; set; }
    }
}
