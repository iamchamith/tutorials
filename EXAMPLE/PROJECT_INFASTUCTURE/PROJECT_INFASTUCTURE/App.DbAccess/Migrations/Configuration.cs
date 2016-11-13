namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<App.DbAccess.EMSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(App.DbAccess.EMSDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Employees.AddOrUpdate(
              new Domain.Employee { Email = "iamchamith@gmail.com", Name = "Chamith", Phone = "0718920205", RegDate = DateTime.Today },
                          new Domain.Employee { Email = "gayan@gmail.com", Name = "Gayan", Phone = "0318920205", RegDate = DateTime.Today },
                                        new Domain.Employee { Email = "sandun@gmail.com", Name = "Sandun", Phone = "0748920205", RegDate = DateTime.Today }
              );
            //
        }
    }
}
