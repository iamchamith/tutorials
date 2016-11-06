using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.TasksModel
{

    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [DefaultValue("no.jpg")]
        public string Image { get; set; }
        [Required]
        public string Address { get; set; }

    }
}
