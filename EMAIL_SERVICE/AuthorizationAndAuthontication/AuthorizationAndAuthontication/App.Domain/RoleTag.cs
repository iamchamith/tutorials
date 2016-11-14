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
    [Table("RoleTag")]
    public class RoleTag
    {
        [Key]
        public string TagId { get; set; }
        public string Description { get; set; }
    }
}
