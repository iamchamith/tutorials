namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<App.DbAccess.PlutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(App.DbAccess.PlutoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.E.g.

            context.Brands.AddOrUpdate(
             new Domain.Brand { Name = "Toyota", Description = "Toyota Japan" },
              new Domain.Brand { Name = "Nissan", Description = "Nissan Japan" },
               new Domain.Brand { Name = "Mitsubishi", Description = "Mitsubishi Japan" }
            );

            context.Models.AddOrUpdate(
                new Domain.Model { Name = "Auqa", Description = "hibrid", BrandId = 1 },
                 new Domain.Model { Name = "Vitz", Description = "patrol", BrandId = 1 }
                );

        }
    }
}
