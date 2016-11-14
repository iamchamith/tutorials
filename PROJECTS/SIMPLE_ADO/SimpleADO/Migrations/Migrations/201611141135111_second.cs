namespace Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            this.Sql("delete from StudentBasic;delete from StudentMore");
        }
        
        public override void Down()
        {

        }
    }
}
