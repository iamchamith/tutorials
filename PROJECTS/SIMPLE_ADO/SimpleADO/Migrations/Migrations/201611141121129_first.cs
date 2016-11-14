namespace Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentBasic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        RegDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentMore",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        School = c.String(nullable: false, maxLength: 50),
                        Dob = c.DateTime(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.StudentBasic", t => t.StudentId)
                .Index(t => t.StudentId);
 
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentMore", "StudentId", "dbo.StudentBasic");
            DropIndex("dbo.StudentMore", new[] { "StudentId" });
            DropTable("dbo.StudentMore");
            DropTable("dbo.StudentBasic");
        }
    }
}
