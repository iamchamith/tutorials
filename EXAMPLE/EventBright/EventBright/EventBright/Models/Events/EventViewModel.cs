using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventBright.Models.Events
{
    public class EventViewModel
    {

        [Key]
        public int EventId { get; set; }
        [Required(ErrorMessage ="Event Titile requred")]
        [StringLength(50)]
        public string Titile { get; set; }
        [Required(ErrorMessage ="Event location requred")]
        public string Location { get; set; }
        public string LatLon { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Image { get; set; }
        [Required]
        public DateTime RegDate { get; set; }
        public int EventCategoryId { get; set; }
    }
}