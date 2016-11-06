using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
//using Dapper;
//using DapperExtensions;
namespace Dapper
{
    public class ConnectionFactory
    {
        static SqlConnection conn = new SqlConnection();
        static string connS = @"Data Source=DELL\SQLEXPRESS;Initial Catalog=VMS;Integrated Security=True;Pooling=False";
        public static IDbConnection GetConnection() {
            try
            {
                if (conn.State!= System.Data.ConnectionState.Open)
                {
                    conn = new SqlConnection(connS);
                    conn.Open();
                }
                return conn;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
