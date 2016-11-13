using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSystem.Data.Helpers
{
    public class ConnectionFactory
    {
        
        public static IDbConnection Connection
        {
            get
            {
                return new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["EMSConnectionString"].ConnectionString);
            }
        }
    }
}
