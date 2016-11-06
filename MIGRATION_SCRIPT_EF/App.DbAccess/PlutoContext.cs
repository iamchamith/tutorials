using App.Model;
using App.TasksModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace App.DbAccess
{
    public class PlutoContext : DbContext
    {
        public PlutoContext() : base(@"Data Source=DELL\SQLEXPRESS;Initial Catalog=VMS;Integrated Security=True;Pooling=False") {

        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Model.Model> Models { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Labour> Labours { get; set; }
        public DbSet<Model.Tasks> Taskss { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleJobs> VehicleJobss { get; set; }
        public DbSet<VehicleJobTasks> LaboursVehicleJobTaskss { get; set; }
        public DbSet<VehicleJobTasksItems> VehicleJobTasksItemss { get; set; }

        public DbSet<VehicelJobTasksLabours> VehicelJobTasksLabours { get; set; }


    }
}
