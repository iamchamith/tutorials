using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    [Table("User")]
    public class User
    {
        [Key]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [DefaultValue(0)]
        public int State { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Nic has error length")]
        public string Nic { get; set; }
        public DateTime RegDate { get; set; }

        public ICollection<Vehicle> Vechicles { get; set; }
        public User() {
            Vechicles = new List<Vehicle>();
        }
    }
}
