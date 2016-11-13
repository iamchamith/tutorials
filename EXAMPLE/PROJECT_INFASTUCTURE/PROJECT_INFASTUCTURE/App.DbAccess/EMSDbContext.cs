using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using App.Domain;

namespace App.DbAccess
{
    public class EMSDbContext : DbContext
    {
        public EMSDbContext() : base(@"Data Source=DELL\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True;Pooling=False") { }

        public DbSet<Employee> Employees { get; set; }

    }
}
