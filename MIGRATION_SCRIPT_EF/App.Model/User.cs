using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace App.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        public string Nic { get; set; }
        public string Password { get; set; }
        public int State { get; set; }

        public DateTime RegDate { get; set; }
        [DefaultValue(true)]
        public bool Active { get; set; }
    }
}
