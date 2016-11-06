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

             
              context.Brands.AddOrUpdate(
                   new Model.Brand { Name = "Toyota" },
                    new Model.Brand { Name = "Nissan" },
                   new Model.Brand { Name = "Micro" }
              );

            //models
            context.Models.AddOrUpdate(
                 new Model.Model { Name = "Auqa",BrandId=1 },
                  new Model.Model { Name = "Starlet",BrandId = 1 },
                 new Model.Model { Name = "Panda",BrandId = 3 },
                 new Model.Model { Name = "Sunney", BrandId = 2 }

            );

        }
    }
}
