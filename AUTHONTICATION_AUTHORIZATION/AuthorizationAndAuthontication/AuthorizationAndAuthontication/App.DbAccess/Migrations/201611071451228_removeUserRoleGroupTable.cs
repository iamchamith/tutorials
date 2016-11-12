namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeUserRoleGroupTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoleGroup", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRoleGroup", "UserId", "dbo.User");
            DropIndex("dbo.UserRoleGroup", new[] { "RoleId" });
            DropIndex("dbo.UserRoleGroup", new[] { "UserId" });
            AddColumn("dbo.User", "RoleId", c => c.String(nullable: false));
            DropTable("dbo.UserRoleGroup");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoleGroup",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId });
            
            DropColumn("dbo.User", "RoleId");
            CreateIndex("dbo.UserRoleGroup", "UserId");
            CreateIndex("dbo.UserRoleGroup", "RoleId");
            AddForeignKey("dbo.UserRoleGroup", "UserId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.UserRoleGroup", "RoleId", "dbo.Role", "RoleId", cascadeDelete: true);
        }
    }
}
