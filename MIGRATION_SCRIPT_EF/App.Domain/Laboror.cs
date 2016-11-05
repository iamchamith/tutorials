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
    [Table("Labour")]
    public class Laboror
    {
        [Key]
        public int Id { get; set; }
        [Required][StringLength(50)]
        public string Name { get; set; }
        [DefaultValue(0)]
        public int? Type { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(50)]
        [Required]
        public string Email { get; set; }
        [StringLength(10)]
        [Required]
        public string Nic { get; set; }
    }
}

