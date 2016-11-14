using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace SimpleADO
{
    public class DbAccess
    {
        public static string ConnectionString;
        static SqlConnection conn = new SqlConnection();

        // open the connection
        public static SqlConnection GetConnection()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn = new SqlConnection(ConnectionString);
                    conn.Open();
                }
                return conn;
            }
            catch
            {
                throw;
            }
        }

        // use for execute all insert,update,delete queries
        public static void Update(string sql, bool enableTransaction = false)
        {
            SqlTransaction tra = null;
            try
            {
                if (enableTransaction)
                {
                    var conn = GetConnection();
                    tra = conn.BeginTransaction();
                    using (var cmd = new SqlCommand(sql, conn, tra))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    tra.Commit();
                }
                else
                {
                    using (var cmd = new SqlCommand(sql, GetConnection()))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                if (enableTransaction)
                {
                    tra.Rollback();
                }
                throw;
            }
        }
        // execute update quary with sql parameters
        public static void Update(string sql, List<SqlParameter> sqlParameters, bool enableTransaction = false)
        {
            SqlTransaction tra = null;
            try
            {
                if (enableTransaction)
                {
                    var conn = GetConnection();
                    tra = conn.BeginTransaction();
                    using (var cmd = new SqlCommand(sql, conn, tra))
                    {
                        cmd.Parameters.AddRange(sqlParameters.ToArray());
                        cmd.ExecuteNonQuery();
                    }
                    tra.Commit();
                }
                else
                {
                    using (var cmd = new SqlCommand(sql, GetConnection()))
                    {
                        cmd.Parameters.AddRange(sqlParameters.ToArray());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                if (enableTransaction)
                {
                    tra.Rollback();
                }
                throw;
            }
        }
        // execute quary with transaction scope with sql parameters
        public static void Update(string sql, List<SqlParameter> sqlParameters, SqlConnection conn, SqlTransaction tra)
        {
            try
            {
                using (var cmd = new SqlCommand(sql, conn, tra))
                {
                    cmd.Parameters.Add(sqlParameters.ToArray());
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        // execute quary with transaction scope without sql parameters
        public static void Update(string sql, SqlConnection conn, SqlTransaction tra)
        {
            try
            {
                using (var cmd = new SqlCommand(sql, conn, tra))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //select for all select queries
        public static DataSet Select(string sql)
        {

            try
            {
                var ds = new DataSet();
                using (var da = new SqlDataAdapter(sql, GetConnection()))
                {
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //execute select with sql parameters
        public static DataSet Select(string sql, List<SqlParameter> sqlParametes)
        {

            try
            {
                var ds = new DataSet();
                var cmd = new SqlCommand(sql, GetConnection());
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.Parameters.AddRange(sqlParametes.ToArray());
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // execute select with sp
        public DataSet SpExec(string spName, List<SqlParameter> sqlParameters, out List<SqlParameter> sqlParameterOut)
        {
            try
            {
                using (var cmd = new SqlCommand(spName, GetConnection()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(sqlParameters.ToArray());
                    var ds = new DataSet();
                    var da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    var outPara = new List<SqlParameter>();
                    outPara.AddRange(sqlParameters.Where(p => p.Direction == ParameterDirection.Output ||
                     p.Direction == ParameterDirection.ReturnValue));
                    sqlParameterOut = outPara;
                    return ds;
                }
            }
            catch { throw; }
        }

    }
}

