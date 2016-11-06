using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Bo
{
    public class EventBo
    {
        [Key]
        public int EventId { get; set; }
        public string Titile { get; set; }
        public string Location { get; set; }
        public string LatLon { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Image { get; set; }
        public DateTime RegDate { get; set; }
        public int EventCategoryId { get; set; }
        public Guid InsertedUserId { get; set; }
    }
}

