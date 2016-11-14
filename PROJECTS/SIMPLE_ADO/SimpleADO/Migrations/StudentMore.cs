using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MigrationsScript
{
    [Table("StudentMore")]
    public class StudentMore
    {
        [Key]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public StudentBasic StudentBasic { get; set; }
        [Required]
        [StringLength(50)]
        public string School { get; set; }

        public DateTime Dob { get; set; }
        [Required]
        [StringLength(10)]
        public string Phone { get; set; }
    }
}
