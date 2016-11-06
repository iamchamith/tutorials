using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Domain
{
    public class SubjectModules
    {
        [Key]
        public int SubjectModuleId { get; set; }

        public int SubjectId { get; set; }
        public string ModuleName { get; set; }

        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
    }
}
