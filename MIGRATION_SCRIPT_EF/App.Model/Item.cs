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
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [DefaultValue(1)]
        public int ReorderLevel { get; set; }
        [DefaultValue(0.00)]
        public float PriceIn { get; set; }
        [DefaultValue(0.00)]
        public float PriceOut { get; set; }
        [DefaultValue(0)]
        public int Quntity { get; set; }

    }
}
