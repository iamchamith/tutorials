namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ReorderLevel = c.Int(nullable: false),
                        PriceIn = c.Single(nullable: false),
                        PriceOut = c.Single(nullable: false),
                        Quntity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateTable(
                "dbo.Labours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Nic = c.String(nullable: false, maxLength: 10),
                        RegDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Nic = c.String(nullable: false, maxLength: 10),
                        Password = c.String(),
                        State = c.Int(nullable: false),
                        RegDate = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.Labours");
            DropTable("dbo.Items");
        }
    }
}
