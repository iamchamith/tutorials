namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRelationbetweenvehicleandvehiceljob : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleJobs", "VehicleId", c => c.String(maxLength: 128));
            CreateIndex("dbo.VehicleJobs", "VehicleId");
            AddForeignKey("dbo.VehicleJobs", "VehicleId", "dbo.Vehicles", "VehicleNo");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleJobs", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.VehicleJobs", new[] { "VehicleId" });
            AlterColumn("dbo.VehicleJobs", "VehicleId", c => c.String());
        }
    }
}
