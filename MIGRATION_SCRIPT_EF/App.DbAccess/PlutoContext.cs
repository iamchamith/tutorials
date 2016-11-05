using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using App.DbAccess;
using App.Domain;

namespace App.DbAccess
{
    public class PlutoContext : DbContext
    {
        public PlutoContext() : base(@"Data Source=DELL\SQLEXPRESS;Initial Catalog=TESTEEE;Integrated Security=True;Pooling=False")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Domain.Task> Tasks{ get; set; }
        public DbSet<Laboror> Laborors { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<VehicleJobs> VehicleJobs { get; set; }
        public DbSet<VehicleJobTasks> VehicleJobTasks { get; set; }
        public DbSet<VehicleJobTaskItem> VehicleJobTaskItems { get; set; }
    }
}
