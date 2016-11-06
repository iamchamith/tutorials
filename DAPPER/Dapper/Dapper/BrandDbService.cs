using App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
namespace Dapper
{
    public class BrandDbService
    {
        public void Create(Brand item)
        {

            using (var con = ConnectionFactory.GetConnection())
            {
                try
                {
                    con.Execute("insert into Brand(Name) value (@Name)", new { Name = item.Name });
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
    }
}
