using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManegementSystem.Models
{
    public class SubjectViewModel
    {
        public int SubjectId { get; set; }
        [Required (ErrorMessage ="Subject name Requred")]
        public string Name { get; set; }
        [Required]
        public decimal Fee { get; set; }
    }
}
