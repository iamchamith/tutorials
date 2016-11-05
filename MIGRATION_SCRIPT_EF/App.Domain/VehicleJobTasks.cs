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
    public class VehicleJobTasks
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int JobId { get; set; }
        [ForeignKey("JobId")]
        public VehicleJobs VehicleJob { get; set; }
         
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        [DefaultValue(false)]
        public bool IsClosed { get; set; }

        [DefaultValue(0.00)]
        public decimal TaskCost { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
        public VehicleJobTasks()
        {
            Tasks = new List<Task>();
        }
    }
}
