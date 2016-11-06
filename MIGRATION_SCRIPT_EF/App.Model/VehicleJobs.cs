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
    public class VehicleJobs
    {
        [Key]
        public int Id { get; set; }

        public string VehicleId { get; set; }

        public DateTime RegDate { get; set; }

        public int UserId { get; set; }

        [DefaultValue(false)]
        public bool IsClosed { get; set; }
        [DefaultValue(0.00)]
        public float FinalAmount { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<VehicleJobTasks> VehicleJobTasks { get; set; }

        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }

        public VehicleJobs() {
            Vehicles = new List<Vehicle>();
            VehicleJobTasks = new List<VehicleJobTasks>();
        }
    }
}
