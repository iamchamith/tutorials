namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactor2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.VehicleJobTasks", "TaskId");
            AddForeignKey("dbo.VehicleJobTasks", "TaskId", "dbo.Tasks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleJobTasks", "TaskId", "dbo.Tasks");
            DropIndex("dbo.VehicleJobTasks", new[] { "TaskId" });
        }
    }
}
