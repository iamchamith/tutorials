namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterEmployeeTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employee", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employee", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employee", "Phone", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employee", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Employee", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Employee", "Name", c => c.String(nullable: false));
        }
    }
}
