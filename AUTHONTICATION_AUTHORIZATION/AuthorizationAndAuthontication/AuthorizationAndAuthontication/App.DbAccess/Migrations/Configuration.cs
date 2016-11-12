using App.Domain;

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
            context.Roles.AddOrUpdate(
                new Role {RoleId = "Citizen ", RoleDescription = "Citizen"},
                new Role {RoleId = "Guest ", RoleDescription = "Guest"},
                new Role {RoleId = "Staff", RoleDescription = "Staff"},
                new Role {RoleId = "Admin", RoleDescription = "Admin"}
                );

            context.RoleTags.AddOrUpdate(
                new RoleTag {TagId = "site/guest/login", Description = "Login Page"},
                new RoleTag {TagId = "site/guest/register", Description = "Register Page"},
                new RoleTag {TagId = "site/guest/forgetPassword", Description = "forgetPassword"},
                new RoleTag {TagId = "site/user/changePassword", Description = "changePassword"},
                new RoleTag {TagId = "site/user/Profile", Description = "Profile"},
                new RoleTag {TagId = "site/user/changeSettings", Description = "changeSettings"},
                new RoleTag {TagId = "site/user/ListUser", Description = "ListUser"}
                );

            context.RoleAccess.AddOrUpdate(
                new RoleAccess {RoleId = "Citizen", Tag = "site/guest/login"},
                new RoleAccess {RoleId = "Guest", Tag = "site/guest/login"},
                new RoleAccess {RoleId = "Staff", Tag = "site/guest/login"},
                new RoleAccess {RoleId = "Admin", Tag = "site/guest/login"},

                new RoleAccess {RoleId = "Citizen", Tag = "site/guest/register"},
                new RoleAccess {RoleId = "Guest", Tag = "site/guest/register"},
                new RoleAccess {RoleId = "Staff", Tag = "site/guest/register"},
                new RoleAccess {RoleId = "Admin", Tag = "site/guest/register"},

                new RoleAccess {RoleId = "Citizen", Tag = "site/guest/forgetPassword"},
                new RoleAccess {RoleId = "Guest", Tag = "site/guest/forgetPassword"},
                new RoleAccess {RoleId = "Staff", Tag = "site/guest/forgetPassword"},
                new RoleAccess {RoleId = "Admin", Tag = "site/guest/forgetPassword"},

                new RoleAccess {RoleId = "Citizen", Tag = "site/user/changePassword"},
                new RoleAccess {RoleId = "Staff", Tag = "site/user/changePassword"},
                new RoleAccess {RoleId = "Admin", Tag = "site/user/changePassword"},

                new RoleAccess {RoleId = "Citizen", Tag = "site/user/Profile"},
                new RoleAccess {RoleId = "Staff", Tag = "site/user/Profile"},
                new RoleAccess {RoleId = "Admin", Tag = "site/user/Profile"},

                new RoleAccess {RoleId = "Citizen", Tag = "site/user/changeSettings"},
                new RoleAccess {RoleId = "Staff", Tag = "site/user/changeSettings"},
                new RoleAccess {RoleId = "Admin", Tag = "site/user/changeSettings"},

                new RoleAccess {RoleId = "Staff", Tag = "site/user/ListUser"},
                new RoleAccess {RoleId = "Admin", Tag = "site/user/ListUser"}

                );

            context.EmailConfigs.AddOrUpdate(new EmailConfig()
            {
                EnableSSL = true,
                Password = "chamith.solid@1234",
                SendEmail = "chamith.solid@gmail.com",
                PortNumber = 587,
                SmtpAddress = "smtp.gmail.com"
            });
        }
    }
}
