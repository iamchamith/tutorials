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
    public class VehicleJobTaskItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int VehicelJobTaskId { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public string Discription { get; set; }
        [StringLength(50)]
        public string UserEmail { get; set; }

        public DateTime RegDate { get; set; }

        [ForeignKey("UserEmail")]
        public User User { get; set; }
        [ForeignKey("ItemId")]
        public Item Item { get; set; }
        [ForeignKey("VehicelJobTaskId")]
        public virtual VehicleJobTasks VehicleJobTasks { get; set; }
    }
}
