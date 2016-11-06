namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => new { t.CustomerId, t.EventId })
                .ForeignKey("dbo.Event", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Titile = c.String(nullable: false, maxLength: 50),
                        Location = c.String(nullable: false),
                        LatLon = c.String(),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        Image = c.String(),
                        RegDate = c.DateTime(nullable: false),
                        EventCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.EventCategory", t => t.EventCategoryId, cascadeDelete: true)
                .Index(t => t.EventCategoryId);
            
            CreateTable(
                "dbo.EventCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Event", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerCart", "CustomerId", "dbo.User");
            DropForeignKey("dbo.CustomerCart", "EventId", "dbo.Event");
            DropForeignKey("dbo.TicketTypes", "EventId", "dbo.Event");
            DropForeignKey("dbo.Event", "EventCategoryId", "dbo.EventCategory");
            DropIndex("dbo.TicketTypes", new[] { "EventId" });
            DropIndex("dbo.Event", new[] { "EventCategoryId" });
            DropIndex("dbo.CustomerCart", new[] { "EventId" });
            DropIndex("dbo.CustomerCart", new[] { "CustomerId" });
            DropTable("dbo.User");
            DropTable("dbo.TicketTypes");
            DropTable("dbo.EventCategory");
            DropTable("dbo.Event");
            DropTable("dbo.CustomerCart");
        }
    }
}
