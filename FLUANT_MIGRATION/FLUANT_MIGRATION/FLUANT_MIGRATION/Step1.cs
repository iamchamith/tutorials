using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLUANT_MIGRATION
{
    public class Step1:Migration
    {
        public override void Up()
        {
            Create.Table("Users");
          
        }

        public override void Down()
        {
             Delete.Table("Users");
        }
    }
}
