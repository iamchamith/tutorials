namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createbrandTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Brand");
        }
    }
}
