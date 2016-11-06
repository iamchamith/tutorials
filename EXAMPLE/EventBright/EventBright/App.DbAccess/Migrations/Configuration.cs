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
            context.EventCategorys.AddOrUpdate(
            new Domain.EventCategory { Name = "Birth Day" },
            new Domain.EventCategory { Name = "Wedding" },
            new Domain.EventCategory { Name = "Get to gether" }
            );

        }
    }
}
