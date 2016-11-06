using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventBright.Models.Events
{
    public class TicketTypeViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage ="Tickert type name requred")]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int EventId { get; set; }
    }
}