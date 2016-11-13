using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain;

namespace App.DbAccess
{
    public class PlutoContext : DbContext
    {
        public PlutoContext() : base(@"Data Source=DELL\SQLEXPRESS1;Initial Catalog=nunit;Integrated Security=True;Pooling=False")
        {
        }

        public DbSet<Employee> Employees{ get; set; }
    }
}
