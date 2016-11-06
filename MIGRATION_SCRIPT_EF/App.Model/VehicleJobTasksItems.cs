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
    public class VehicleJobTasksItems
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Qunatity { get; set; }

        public int VehicleJobTasksId { get; set; }

        [ForeignKey("VehicleJobTasksId")]
        public VehicleJobTasks VehicleJobTasks { get;set;}

    }
}
