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
    [Table("Role")]
    public class Role
    {
        [Key]
        public string RoleId { get; set; }
        public string RoleDescription { get; set; }
    }
}
