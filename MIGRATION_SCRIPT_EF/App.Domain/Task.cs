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
    [Table("Task")]
    public class Task
    {
        [Key]
        public string Id { get; set; }
        [Required][StringLength(50)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        public virtual VehicleJobTaskItem VehicleJobTaskItem { get; set; }
    }
}
