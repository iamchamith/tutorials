namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createEmailtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailConfig",
                c => new
                    {
                        SendEmail = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                        SmtpAddress = c.String(nullable: false),
                        PortNumber = c.Int(nullable: false),
                        EnableSSL = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SendEmail);
            
            AddColumn("dbo.UserToken", "Email", c => c.String(nullable: false));
            DropColumn("dbo.UserToken", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserToken", "UserId", c => c.String(nullable: false));
            DropColumn("dbo.UserToken", "Email");
            DropTable("dbo.EmailConfig");
        }
    }
}
