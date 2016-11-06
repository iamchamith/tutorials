namespace EF.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddErrorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        ErrorId = c.Int(nullable: false, identity: true),
                        ExceptionMessage = c.String(),
                        StackTrace = c.String(),
                        User = c.String(),
                        LogDateTime = c.DateTime(nullable: false),
                        Action = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ErrorId);

           
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Errors");
        }
    }
}
