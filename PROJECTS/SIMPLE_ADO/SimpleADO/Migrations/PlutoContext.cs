using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace MigrationsScript
{
    public class PlutoContext:DbContext
    {
        public PlutoContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GIT\TUTORIALS\PROJECTS\SIMPLE_ADO\SimpleADO\Migrations\Sample.mdf;Integrated Security=True") { }

        public DbSet<StudentBasic> StudentBasic { get; set; }
        public DbSet<StudentMore> StudentMore { get; set; }
    }
}
