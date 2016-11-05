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
    [Table("Model")]
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required][StringLength(50)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        public virtual  ICollection<Vehicle> Vechicles { get; set; }
        public Model()
        {
            Vechicles = new List<Vehicle>();
        }

    }
}
