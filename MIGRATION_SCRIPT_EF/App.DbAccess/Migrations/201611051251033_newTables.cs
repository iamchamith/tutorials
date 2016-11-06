namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleJobTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobId = c.Int(nullable: false),
                        TaskId = c.Int(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleId = c.String(),
                        RegDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                        FinalAmount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleJobTasksItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Qunatity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleNo = c.String(nullable: false, maxLength: 128),
                        EngineNumber = c.String(nullable: false, maxLength: 50),
                        ChassiNumber = c.String(nullable: false, maxLength: 50),
                        Image = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.VehicleNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
            DropTable("dbo.VehicleJobTasksItems");
            DropTable("dbo.VehicleJobs");
            DropTable("dbo.VehicleJobTasks");
        }
    }
}
