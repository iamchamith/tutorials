using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManegementSystem.Models
{
    public class StudentSubjectViewModel: SubjectViewModel
    {
        public int StudentId { get; set; }
        public DateTime RegDate { get; set; }
    }
}
