using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using App.Domain;

namespace App.DbAccess
{
    public class PlutoContext:DbContext
    {
        public PlutoContext() : base(@"Data Source=JET-DEV03\TOWNSUITE;Initial Catalog=AuthonticatinoAndAuthorization;Integrated Security=True")
        {

        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Users> Users_ { get; set; }
        public DbSet<RoleTag> RoleTags { get; set; }
        public DbSet<RoleAccess> RoleAccess { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<UserPreferences> UserPreferences { get; set; }
        public DbSet<EmailConfig> EmailConfigs { get; set; }
    }
}
