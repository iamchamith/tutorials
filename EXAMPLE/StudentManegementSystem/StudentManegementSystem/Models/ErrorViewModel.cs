using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManegementSystem.Models
{
    public class ErrorViewModel
    {
        public int ErrorId { get; set; }
        public object Reuqest { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }
        public string User { get; set; }
        public DateTime LogDateTime { get; set; }
        public int Action { get; set; }

    }
}
