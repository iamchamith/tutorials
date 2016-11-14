using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormSimpleAdo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // set connection string
            SimpleADO.DbAccess.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GIT\TUTORIALS\PROJECTS\SIMPLE_ADO\SimpleADO\Migrations\Sample.mdf;Integrated Security=True";

            Application.Run(new Form1());
        }
    }
}
