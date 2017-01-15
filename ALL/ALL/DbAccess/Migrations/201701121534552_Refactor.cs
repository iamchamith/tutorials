namespace DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HireDate = c.DateTime(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Staffs");
        }
    }
}
