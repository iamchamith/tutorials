namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeDepartment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropColumn("dbo.Employee", "DepartmentId");
            DropTable("dbo.Department");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employee", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employee", "DepartmentId");
            AddForeignKey("dbo.Employee", "DepartmentId", "dbo.Department", "Id", cascadeDelete: true);
        }
    }
}
