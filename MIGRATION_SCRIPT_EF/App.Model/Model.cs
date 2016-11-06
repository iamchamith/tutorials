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
    [Table("Model")]
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brands { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public Model() {
            Vehicles = new List<Vehicle>();
        }
    }
}
