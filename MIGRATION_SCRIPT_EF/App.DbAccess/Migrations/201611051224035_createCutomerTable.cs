namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createCutomerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false),
                        Image = c.String(),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Brand", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Model", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Model", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Brand", "Name", c => c.String(maxLength: 50));
            DropTable("dbo.Customers");
        }
    }
}
