using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManegementSystem.Models
{
    public class SubjectViewViewModel
    {
        public SubjectViewModel subjectVieModel { get; set; }
        public List<string> subjectModuleList { get; set; }
    }
}