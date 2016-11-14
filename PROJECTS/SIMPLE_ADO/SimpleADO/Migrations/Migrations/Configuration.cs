namespace Migrations.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MigrationsScript.PlutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
 
        protected override void Seed(MigrationsScript.PlutoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            //context.StudentBasic.RemoveRange(context.StudentBasic.ToList());
            //context.SaveChanges();
            var one = context.StudentBasic.Add(new MigrationsScript.StudentBasic { Email = "iamchamith@gmail.com", Name = "Chamith Saranga", RegDate = DateTime.Today });
            var two = context.StudentBasic.Add(new MigrationsScript.StudentBasic { Email = "sajeeka@gmail.com", Name = "Sajeeka", RegDate = DateTime.Today });
            var three = context.StudentBasic.Add(new MigrationsScript.StudentBasic { Email = "ruwan@gmail.com", Name = "Ruwan", RegDate = DateTime.Today });


            context.SaveChanges();
            context.StudentMore.Add(
                new MigrationsScript.StudentMore
                {
                    Dob = DateTime.Today.AddYears(new Random().Next(10, 15)),
                    Phone = "123132",
                    School = "De mazenod college",
                    StudentId = one.Id
                });
            context.StudentMore.Add(
               new MigrationsScript.StudentMore
               {
                   Dob = DateTime.Today.AddYears(new Random().Next(10, 15)),
                   Phone = "123132",
                   School = "De mazenod college",
                   StudentId = two.Id
               });
            context.StudentMore.Add(
               new MigrationsScript.StudentMore
               {
                   Dob = DateTime.Today.AddYears(new Random().Next(10, 15)),
                   Phone = "123132",
                   School = "De mazenod college",
                   StudentId = three.Id
               });
            context.SaveChanges();
        }
    }
}
