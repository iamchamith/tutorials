using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Domain
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DefaultValue(0.0)]
        public decimal Fee { get; set; }

        [NotMapped]
        public DateTime RegDate { get; set; }

        public virtual ICollection<SubjectModules> SubjectModules { get; set; }

        public Subject() {
            SubjectModules = new List<SubjectModules>();
        }
    }
}
