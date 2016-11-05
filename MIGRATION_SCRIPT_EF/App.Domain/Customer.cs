using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace App.Domain
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required][StringLength(20)]
        public string Phone { get; set; }
        [Required][StringLength(200)]
        public string Address { get; set; }
        [Required][StringLength(50)]
        public string Email { get; set; }
        [DefaultValue("no.jpg")]
        [StringLength(100)]
        public string Url { get; set; }
        public DateTime RegDate { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public Customer() {
            Vehicles = new List<Vehicle>();
        }
    }
}
