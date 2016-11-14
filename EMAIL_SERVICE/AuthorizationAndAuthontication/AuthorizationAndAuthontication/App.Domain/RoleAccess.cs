using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace App.Domain
{
    [Table("RoleAccess")]
    public class RoleAccess
    {
        [Key]
        [Column(Order = 0)]
        public string RoleId { get; set; }
        [Key]
        [Column(Order = 1)]
        public string Tag { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
        [ForeignKey("Tag")]
        public virtual RoleTag RoleTag { get; set; }
    }
}
