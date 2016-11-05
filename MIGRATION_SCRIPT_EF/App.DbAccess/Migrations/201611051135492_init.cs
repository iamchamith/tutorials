namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.BrandId);
            
            CreateTable(
                "dbo.Model",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        BrandId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brand", t => t.BrandId, cascadeDelete: true)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleNumber = c.String(nullable: false, maxLength: 128),
                        BrandId = c.Int(nullable: false),
                        EngineNumber = c.String(maxLength: 50),
                        ChassyNumber = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                        Owner = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        RegDate = c.DateTime(nullable: false),
                        Url = c.String(maxLength: 10),
                        Model_Id = c.Int(),
                        VehicleJobs_Id = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleNumber)
                .ForeignKey("dbo.Brand", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.Owner, cascadeDelete: true)
                .ForeignKey("dbo.Model", t => t.Model_Id)
                .ForeignKey("dbo.User", t => t.Email, cascadeDelete: true)
                .ForeignKey("dbo.VehicleJobs", t => t.VehicleJobs_Id)
                .Index(t => t.BrandId)
                .Index(t => t.Owner)
                .Index(t => t.Email)
                .Index(t => t.Model_Id)
                .Index(t => t.VehicleJobs_Id);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 50),
                        Url = c.String(maxLength: 100),
                        RegDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(),
                        Description = c.String(nullable: false, maxLength: 500),
                        PriceIn = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceOut = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(),
                        ReorderLevel = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Labour",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Type = c.Int(),
                        Description = c.String(maxLength: 500),
                        Email = c.String(nullable: false, maxLength: 50),
                        Nic = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        VehicleJobTasks_Id = c.Int(),
                        VehicleJobTaskItem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleJobTasks", t => t.VehicleJobTasks_Id)
                .ForeignKey("dbo.VehicleJobTaskItems", t => t.VehicleJobTaskItem_Id)
                .Index(t => t.VehicleJobTasks_Id)
                .Index(t => t.VehicleJobTaskItem_Id);
            
            CreateTable(
                "dbo.VehicleJobTaskItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicelJobTaskId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Discription = c.String(),
                        UserEmail = c.String(maxLength: 50),
                        RegDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserEmail)
                .ForeignKey("dbo.VehicleJobTasks", t => t.VehicelJobTaskId, cascadeDelete: true)
                .Index(t => t.VehicelJobTaskId)
                .Index(t => t.ItemId)
                .Index(t => t.UserEmail);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        State = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Nic = c.String(nullable: false, maxLength: 10),
                        RegDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.VehicleJobTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobId = c.Int(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                        TaskCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleJobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.JobId);
            
            CreateTable(
                "dbo.VehicleJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsFinished = c.Boolean(nullable: false),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        FinalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "VehicleJobTaskItem_Id", "dbo.VehicleJobTaskItems");
            DropForeignKey("dbo.VehicleJobTaskItems", "VehicelJobTaskId", "dbo.VehicleJobTasks");
            DropForeignKey("dbo.VehicleJobTasks", "JobId", "dbo.VehicleJobs");
            DropForeignKey("dbo.Vehicles", "VehicleJobs_Id", "dbo.VehicleJobs");
            DropForeignKey("dbo.Task", "VehicleJobTasks_Id", "dbo.VehicleJobTasks");
            DropForeignKey("dbo.VehicleJobTaskItems", "UserEmail", "dbo.User");
            DropForeignKey("dbo.Vehicles", "Email", "dbo.User");
            DropForeignKey("dbo.VehicleJobTaskItems", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Vehicles", "Model_Id", "dbo.Model");
            DropForeignKey("dbo.Vehicles", "Owner", "dbo.Customer");
            DropForeignKey("dbo.Vehicles", "BrandId", "dbo.Brand");
            DropForeignKey("dbo.Model", "BrandId", "dbo.Brand");
            DropIndex("dbo.VehicleJobTasks", new[] { "JobId" });
            DropIndex("dbo.VehicleJobTaskItems", new[] { "UserEmail" });
            DropIndex("dbo.VehicleJobTaskItems", new[] { "ItemId" });
            DropIndex("dbo.VehicleJobTaskItems", new[] { "VehicelJobTaskId" });
            DropIndex("dbo.Task", new[] { "VehicleJobTaskItem_Id" });
            DropIndex("dbo.Task", new[] { "VehicleJobTasks_Id" });
            DropIndex("dbo.Vehicles", new[] { "VehicleJobs_Id" });
            DropIndex("dbo.Vehicles", new[] { "Model_Id" });
            DropIndex("dbo.Vehicles", new[] { "Email" });
            DropIndex("dbo.Vehicles", new[] { "Owner" });
            DropIndex("dbo.Vehicles", new[] { "BrandId" });
            DropIndex("dbo.Model", new[] { "BrandId" });
            DropTable("dbo.VehicleJobs");
            DropTable("dbo.VehicleJobTasks");
            DropTable("dbo.User");
            DropTable("dbo.VehicleJobTaskItems");
            DropTable("dbo.Task");
            DropTable("dbo.Labour");
            DropTable("dbo.Item");
            DropTable("dbo.Customer");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Model");
            DropTable("dbo.Brand");
        }
    }
}
