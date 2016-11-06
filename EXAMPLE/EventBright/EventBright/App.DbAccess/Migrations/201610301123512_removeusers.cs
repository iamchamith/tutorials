namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeusers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerCart", "EventId", "dbo.Event");
            DropForeignKey("dbo.CustomerCart", "CustomerId", "dbo.User");
            DropIndex("dbo.CustomerCart", new[] { "CustomerId" });
            DropIndex("dbo.CustomerCart", new[] { "EventId" });
            DropTable("dbo.CustomerCart");
            DropTable("dbo.User");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        Image = c.String(maxLength: 100),
                        Mode = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                        RegDate = c.String(),
                        Token = c.String(maxLength: 50),
                        TokenType = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsVerifyEmail = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.CustomerCart",
                c => new
                    {
                        CustomerId = c.Guid(nullable: false),
                        EventId = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsPaid = c.Boolean(nullable: false),
                        TransactionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerId, t.EventId });
            
            CreateIndex("dbo.CustomerCart", "EventId");
            CreateIndex("dbo.CustomerCart", "CustomerId");
            AddForeignKey("dbo.CustomerCart", "CustomerId", "dbo.User", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.CustomerCart", "EventId", "dbo.Event", "EventId", cascadeDelete: true);
        }
    }
}
