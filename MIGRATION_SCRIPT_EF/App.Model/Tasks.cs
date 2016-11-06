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
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string TaskName { get; set; }
    }
}
