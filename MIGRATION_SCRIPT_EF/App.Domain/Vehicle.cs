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
    public class Vehicle
    {
        [Key]
        public string VehicleNumber { get; set; }
        [Required]
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        [Required]
        public Brand Brand { get; set; }

        [StringLength(50)]
        public string EngineNumber { get; set; }
        [StringLength(50)]
        public string ChassyNumber { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public int Owner { get; set; }
        [ForeignKey("Owner")]
        public Customer Customer { get; set; }
        [Required][StringLength(50)]
        public string Email { get; set; }
        public DateTime RegDate { get; set; }
        [DefaultValue("No.jpg")][StringLength(10)]
        public string Url { get; set; }
        //[Required]
        //public int ModelId { get; set; }
        //[ForeignKey("ModelId")]
        //[Required]
        //public virtual Model Model { get; set; }
    }
}
