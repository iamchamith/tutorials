using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain
{
    public class StudentSubject
    {
        [Column(Order = 0), Key]
        public int StudentId { get; set; }
        [Column(Order = 1), Key]
        public int SubjectId { get; set; }

        public DateTime RegistedDate { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
    }
}
