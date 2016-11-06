namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicelJobTasksLabours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LabourId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Labours", t => t.LabourId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleJobTasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.LabourId)
                .Index(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicelJobTasksLabours", "TaskId", "dbo.VehicleJobTasks");
            DropForeignKey("dbo.VehicelJobTasksLabours", "LabourId", "dbo.Labours");
            DropIndex("dbo.VehicelJobTasksLabours", new[] { "TaskId" });
            DropIndex("dbo.VehicelJobTasksLabours", new[] { "LabourId" });
            DropTable("dbo.VehicelJobTasksLabours");
        }
    }
}
