using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManegementSystem.Models
{
    public class StudentMoreViewModel
    {
        public int StudentId { get; set; }
    
        [Required(ErrorMessage = "Phone number requred")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address requred")]
        public string Address { get; set; }
        [Required(ErrorMessage = "School name requred")]
        public string School { get; set; }
    }
}
