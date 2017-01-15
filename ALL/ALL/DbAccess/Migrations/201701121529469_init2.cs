namespace DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentSubjects",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        RegistedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.SubjectId })
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentSubjects", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.StudentSubjects", "StudentId", "dbo.Student");
            DropIndex("dbo.StudentSubjects", new[] { "SubjectId" });
            DropIndex("dbo.StudentSubjects", new[] { "StudentId" });
            DropTable("dbo.Subject");
            DropTable("dbo.StudentSubjects");
        }
    }
}
