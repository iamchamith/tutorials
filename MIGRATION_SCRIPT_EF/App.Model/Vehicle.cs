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
    public class Vehicle
    {
        [Key]
        [Required]
        public string VehicleNo { get; set; }
        [Required]
        [StringLength(50)]
        public string EngineNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string ChassiNumber { get; set; }
        [Required]
        [StringLength(50)]
        [DefaultValue("no.jpg")]
        public string Image { get; set; }

        public int ModelId { get; set; }

        [ForeignKey("ModelId")]
        public Model Model { get; set; }
    }
}
