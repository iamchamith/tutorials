using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace App.Sp
{
    public class DbAccess
    {
        static SqlConnection conn = new SqlConnection();
        static string connS = @"Data Source=DELL\SQLEXPRESS;Initial Catalog=VMS;Integrated Security=True;Pooling=False";
        static SqlConnection GetConnection() {

            if (conn.State==ConnectionState.Open)
            {
                return conn;
            }
            conn = new SqlConnection(connS);
            conn.Open();
            return conn;

        }

        public static void Update(string sql) {

            using (var cmd = new SqlCommand(sql,GetConnection()))
            {
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex) {
                    var e = ex;
                    throw; }
            }
        }


    }
}
