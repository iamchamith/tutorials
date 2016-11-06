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
    [Table("Event")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        [Required]
        [StringLength(50)]
        public string Titile { get; set; }
        [Required]
        public string Location { get; set; }
        public string LatLon { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        [DefaultValue("no.jpg")]
        public string Image { get; set; }
        [Required]
        public DateTime RegDate { get; set; }

        public ICollection<TicketType> TickertTypes { get; set; }

        public int EventCategoryId { get; set; }

        [ForeignKey("EventCategoryId")]
        public virtual EventCategory EventCategory { get; set; }
        [Required]
        public Guid InsertedUserId { get; set; }
        
    }
}
