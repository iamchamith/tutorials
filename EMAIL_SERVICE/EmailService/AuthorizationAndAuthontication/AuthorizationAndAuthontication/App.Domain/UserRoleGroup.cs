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
    [Table("UserRoleGroup")]
    public class UserRoleGroup
    {
        [Key]
        [Column(Order = 0)]
        public string RoleId { get; set; }
        [Key]
        [Column(Order =1)]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
