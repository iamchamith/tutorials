namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Model",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brand", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Model", "BrandId", "dbo.Brand");
            DropIndex("dbo.Model", new[] { "BrandId" });
            DropTable("dbo.Model");
        }
    }
}
