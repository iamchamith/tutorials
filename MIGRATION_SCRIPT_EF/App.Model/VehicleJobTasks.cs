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
    public class VehicleJobTasks
    {
        [Key]
        public int Id { get; set; }

        public int JobId { get; set; }

        public int TaskId { get; set; }

        [DefaultValue(false)]
        public bool IsClosed { get; set; }

        public int VehicelJob { get; set; }

        [ForeignKey("VehicelJob")]
        public virtual VehicleJobs VehicleJobs { get; set; }

        public virtual ICollection<Labour> Labours { get; set; }

        public virtual ICollection<VehicleJobTasksItems> VehicleJobTasksItems { get; set; }

        [ForeignKey("TaskId")]
        public virtual Tasks Tasks { get; set; }

        public VehicleJobTasks() {
            VehicleJobTasksItems = new List<VehicleJobTasksItems>();
            Labours = new List<Labour>();
        }
    }
}
