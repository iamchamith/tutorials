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
        public PlutoContext() : base(@"Data Source=JET-DEV03\TOWNSUITE;Initial Catalog=UnitTest;Integrated Security=True")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
