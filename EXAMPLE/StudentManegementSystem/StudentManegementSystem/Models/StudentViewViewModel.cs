using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManegementSystem.Models
{
    public class StudentViewViewModel
    {
        public StudentViewModel Student { get; set; }
        public StudentMoreViewModel StudentMore { get; set; }
    }
}