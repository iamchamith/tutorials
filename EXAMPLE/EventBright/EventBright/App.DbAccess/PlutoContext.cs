using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using App.Domain;

namespace App.DbAccess
{
    public class PlutoContext : DbContext
    {
        public PlutoContext() : base(@"Data Source=DELL\SQLEXPRESS;Initial Catalog=EventBright;Integrated Security=True;Pooling=False") { }

        public DbSet<EventCategory> EventCategorys { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
    }
}
