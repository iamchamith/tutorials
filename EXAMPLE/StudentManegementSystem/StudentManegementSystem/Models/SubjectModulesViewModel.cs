using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManegementSystem.Models
{
    public class SubjectModulesViewModel
    {
        public int SubjectModuleId { get; set; }
        public int SubjectId { get; set; }
        [Required (ErrorMessage ="Module name requred")]
        public string ModuleName { get; set; }
    }
}
