namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserPreferences : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPreferences",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        DateTimeFormat = c.String(maxLength: 50),
                        Language = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPreferences", "UserId", "dbo.User");
            DropIndex("dbo.UserPreferences", new[] { "UserId" });
            DropTable("dbo.UserPreferences");
        }
    }
}
