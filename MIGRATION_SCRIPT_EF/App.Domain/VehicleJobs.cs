using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace App.Domain
{
    public class VehicleJobs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [DefaultValue(false)]
        [Required]
        public bool IsFinished { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        [DefaultValue(0.00)]
        public decimal FinalAmount { get; set; }
         
        public virtual ICollection<Vehicle> Vechicles { get; set; }
        public VehicleJobs() {
            Vechicles = new List<Vehicle>();
        }
    }
}
