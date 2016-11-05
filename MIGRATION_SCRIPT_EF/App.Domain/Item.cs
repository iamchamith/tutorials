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
    [Table("Item")]
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [DefaultValue(0)]
        public int? CategoryId { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [DefaultValue(0.00)]
        public decimal PriceIn { get; set; }
        [DefaultValue(0.00)]
        public decimal PriceOut { get; set; }
        [DefaultValue(0)]
        public int? Quantity { get; set; }
        [DefaultValue(0)]
        public int? ReorderLevel { get; set; }
    }
}
