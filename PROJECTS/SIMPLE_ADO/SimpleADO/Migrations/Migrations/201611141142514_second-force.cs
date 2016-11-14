namespace Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondforce : DbMigration
    {
        public override void Up()
        {
            this.Sql("delete from StudentMore;delete from StudentBasic");
        }
        
        public override void Down()
        {
        }
    }
}
