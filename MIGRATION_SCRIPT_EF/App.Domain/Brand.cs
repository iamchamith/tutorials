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
    [Table("Brand")]
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public ICollection<Model> Models { get; set; }
        public ICollection<Vehicle> Vechicles { get; set; }
        public Brand() {
            Models = new List<Model>();
            Vechicles = new List<Vehicle>();
        }
    }
}
