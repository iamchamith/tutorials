namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Labours", "VehicleJobTasks_Id", c => c.Int());
            AddColumn("dbo.VehicleJobTasks", "VehicelJob", c => c.Int(nullable: false));
            AddColumn("dbo.VehicleJobTasksItems", "VehicleJobTasksId", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "ModelId", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "VehicleJobs_Id", c => c.Int());
            CreateIndex("dbo.Vehicles", "ModelId");
            CreateIndex("dbo.Vehicles", "VehicleJobs_Id");
            CreateIndex("dbo.Labours", "VehicleJobTasks_Id");
            CreateIndex("dbo.VehicleJobTasks", "VehicelJob");
            CreateIndex("dbo.VehicleJobTasksItems", "VehicleJobTasksId");
            AddForeignKey("dbo.Vehicles", "ModelId", "dbo.Model", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Labours", "VehicleJobTasks_Id", "dbo.VehicleJobTasks", "Id");
            AddForeignKey("dbo.VehicleJobTasks", "VehicelJob", "dbo.VehicleJobs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Vehicles", "VehicleJobs_Id", "dbo.VehicleJobs", "Id");
            AddForeignKey("dbo.VehicleJobTasksItems", "VehicleJobTasksId", "dbo.VehicleJobTasks", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleJobTasksItems", "VehicleJobTasksId", "dbo.VehicleJobTasks");
            DropForeignKey("dbo.Vehicles", "VehicleJobs_Id", "dbo.VehicleJobs");
            DropForeignKey("dbo.VehicleJobTasks", "VehicelJob", "dbo.VehicleJobs");
            DropForeignKey("dbo.Labours", "VehicleJobTasks_Id", "dbo.VehicleJobTasks");
            DropForeignKey("dbo.Vehicles", "ModelId", "dbo.Model");
            DropIndex("dbo.VehicleJobTasksItems", new[] { "VehicleJobTasksId" });
            DropIndex("dbo.VehicleJobTasks", new[] { "VehicelJob" });
            DropIndex("dbo.Labours", new[] { "VehicleJobTasks_Id" });
            DropIndex("dbo.Vehicles", new[] { "VehicleJobs_Id" });
            DropIndex("dbo.Vehicles", new[] { "ModelId" });
            DropColumn("dbo.Vehicles", "VehicleJobs_Id");
            DropColumn("dbo.Vehicles", "ModelId");
            DropColumn("dbo.VehicleJobTasksItems", "VehicleJobTasksId");
            DropColumn("dbo.VehicleJobTasks", "VehicelJob");
            DropColumn("dbo.Labours", "VehicleJobTasks_Id");
        }
    }
}
