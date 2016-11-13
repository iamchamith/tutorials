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

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Employees.AddOrUpdate(
             new Domain.Employee { Name = "Chamith", Nic = "123456V", Phone = "45454" },
              new Domain.Employee { Name = "Gihan", Nic = "223456V", Phone = "45454" },
                 new Domain.Employee { Name = "Nalaka", Nic = "423456V", Phone = "34454" },
                 new Domain.Employee { Name = "Ranga", Nic = "523456V", Phone = "55454" }
 );
            //
        }
    }
}
