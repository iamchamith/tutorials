using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventBright.Models.Events
{
    public class EventCategoryViewModel
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; }
    }
}