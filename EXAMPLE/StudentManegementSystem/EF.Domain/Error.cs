using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Domain
{
    public class Error
    {
        [Key]
        public int ErrorId { get; set; }
        public object Reuqest { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }
        public string User { get; set; }
        public DateTime LogDateTime { get; set; }
        [DefaultValue(0)]
        public int Action { get; set; }

    }
}
