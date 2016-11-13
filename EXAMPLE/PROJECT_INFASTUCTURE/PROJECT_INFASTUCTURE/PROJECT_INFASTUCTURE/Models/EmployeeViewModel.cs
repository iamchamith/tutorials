using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PROJECT_INFASTUCTURE.Models
{
    public class EmployeeViewModel
    {

        public int Id { get; set; }
        [Required (ErrorMessage ="Employee name must requred")]
        [StringLength(50, ErrorMessage = "It must be below 50")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Employee Email requred")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Employee Phone requred")]
        [StringLength(10,ErrorMessage ="It must be 10")]
        public string Phone { get; set; }
 
    }
}