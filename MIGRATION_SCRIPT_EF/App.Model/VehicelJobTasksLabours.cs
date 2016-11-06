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
    public class VehicelJobTasksLabours
    {
        public int Id { get; set; }

        public int LabourId { get; set; }

        public int TaskId { get; set; }

        [ForeignKey("TaskId")]
        public virtual VehicleJobTasks VehicleJobTasks { get; set; }

        [ForeignKey("LabourId")]
        public virtual Labour Labours { get; set; }

        [DefaultValue(false)]
        public bool IsClosed { get; set; }

    
        public VehicelJobTasksLabours()
        {
          
        }
    }
}
