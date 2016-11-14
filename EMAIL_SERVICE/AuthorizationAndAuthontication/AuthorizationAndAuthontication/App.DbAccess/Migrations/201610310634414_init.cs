namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleAccess",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Tag = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.Tag })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.RoleTag", t => t.Tag, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.Tag);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        RoleDescription = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.RoleTag",
                c => new
                    {
                        TagId = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.UserRoleGroup",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(),
                        Active = c.Boolean(nullable: false),
                        ValidateEmail = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoleGroup", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRoleGroup", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RoleAccess", "Tag", "dbo.RoleTag");
            DropForeignKey("dbo.RoleAccess", "RoleId", "dbo.Role");
            DropIndex("dbo.UserRoleGroup", new[] { "UserId" });
            DropIndex("dbo.UserRoleGroup", new[] { "RoleId" });
            DropIndex("dbo.RoleAccess", new[] { "Tag" });
            DropIndex("dbo.RoleAccess", new[] { "RoleId" });
            DropTable("dbo.User");
            DropTable("dbo.UserRoleGroup");
            DropTable("dbo.RoleTag");
            DropTable("dbo.Role");
            DropTable("dbo.RoleAccess");
        }
    }
}
