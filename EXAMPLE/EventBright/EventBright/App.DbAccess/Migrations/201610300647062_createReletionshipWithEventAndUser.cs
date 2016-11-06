namespace App.DbAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createReletionshipWithEventAndUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "InsertedUserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Event", "InsertedUserId");
        }
    }
}
