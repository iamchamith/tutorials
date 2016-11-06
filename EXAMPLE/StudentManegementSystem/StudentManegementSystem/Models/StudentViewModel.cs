using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManegementSystem.Models
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "School name requred")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Student birthday requred")]
        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Student email requred")]
        public string Email { get; set; }
        public string Image { get; set; }
    }
}
