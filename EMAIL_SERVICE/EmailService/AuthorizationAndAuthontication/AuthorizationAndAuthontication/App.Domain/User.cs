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
    [Table("User")]
    public class User
    {
        [Key]
        public string UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        public string Password { get; set; }
        [DefaultValue(false)]
        public bool Active { get; set; }
        [DefaultValue(false)]
        public bool ValidateEmail { get; set; }

    }
}
