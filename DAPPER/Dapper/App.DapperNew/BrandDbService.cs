using App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace App.DapperNew
{
    public class BrandDbService
    {
        public void Create(Brand item)
        {

            using (var con = ConnectionFactory.GetConnection())
            {
                using (var tra = con.BeginTransaction())
                {
                    try
                    {
                        con.Execute("insert into Brand(Name) values (@Name)", new { Name = item.Name }, tra);
                        con.Execute("insert into Brand(Name) values (@Name)", new { Name = "Volvo" }, tra);
                        con.Execute("insert into Brand(Name) values (@Name)", new { Name = "Suzuki" }, tra);
                        con.Execute("insert into Brand(Name) values (@Name)", new { Name = "Mahendra" }, tra);
                        tra.Commit();
                    }
                    catch (Exception)
                    {
                        tra.Rollback();
                        throw;
                    }
                }

            }
        }

        public void MultipleUpdate(List<Brand> items)
        {

            using (var conn = ConnectionFactory.GetConnection())
            {

                using (var tra = conn.BeginTransaction())
                {

                    try
                    {
                        conn.Execute("insert into Brand(Name) values (@Name)", new[] { new { Name = "Google" }, new { Name = "yahoo" } }, tra);

                        tra.Commit();
                    }
                    catch (Exception)
                    {
                        tra.Rollback();
                        throw;
                    }

                }

            }
        }

        public void Update(Brand item)
        {

            using (var con = ConnectionFactory.GetConnection())
            {
                using (var tra = con.BeginTransaction())
                {
                    try
                    {

                        con.Execute(@"UPDATE       Brand
                        SET  Name = @Name
                        WHERE    (Id = @Id)", new { Name = item.Name, Id = item.Id }, tra);
                        tra.Commit();
                    }
                    catch (Exception)
                    {
                        tra.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<Brand> Select()
        {

            using (var con = ConnectionFactory.GetConnection())
            {

                try
                {
                    return con.Query<Brand>("select * from brand").ToList();
                }
                catch
                {
                    throw;
                }

            }

        }

        public Brand Select(int id)
        {

            using (var con = ConnectionFactory.GetConnection())
            {

                try
                {
                    var x = con.Query<Brand>("select * from brand where id = @id", new { id = id }).FirstOrDefault();
                    return x;
                }
                catch
                {
                    throw;
                }

            }

        }

        public ArrayList SelectMultiple()
        {

            using (var con = ConnectionFactory.GetConnection())
            {

                try
                {
                    var data = con.QueryMultiple("select * from brand;select * from Model");

                    var brand = data.Read<Brand>().ToList();
                    var Model = data.Read<Model>().ToList();

                    return new ArrayList() { brand, Model };
                }
                catch
                {
                    throw;
                }

            }

        }

        public void CreateModelUsingSp(Model item)
        {

            using (var conn = ConnectionFactory.GetConnection())
            {
                using (var tra = conn.BeginTransaction())
                {

                    try
                    {
                        conn.Execute("SP_Model_create", new { Name = item.Name, BrandId = item.BrandId }, commandType: CommandType.StoredProcedure, transaction: tra);
                        tra.Commit();
                    }
                    catch (Exception)
                    {
                        tra.Rollback();
                        throw;
                    }

                }
            }

        }

        public void CreateModelUsingSp(Model item, out int Id, out int returnOne)
        {

            using (var conn = ConnectionFactory.GetConnection())
            {
                using (var tra = conn.BeginTransaction())
                {

                    try
                    {

                        var p = new DynamicParameters();
                        p.Add("@Name", item.Name, direction: ParameterDirection.Input);
                        p.Add("@BrandId", item.BrandId, direction: ParameterDirection.Input);
                        p.Add("@ModelId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                        p.Add("@rrr", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);


                        conn.Execute("SP_Model_create_withOut", p, commandType: CommandType.StoredProcedure, transaction: tra);

                        Id = p.Get<int>("@ModelId");
                        returnOne = p.Get<int>("@rrr");

                        tra.Commit();
                    }
                    catch (Exception)
                    {
                        tra.Rollback();
                        throw;
                    }

                }
            }

        }


        /// <summary>
        /// //////////
        /// </summary>
        /// <param name="model"></param>
        /// <param name="bran"></param>

        public void InsertBrandsAndModels(Model model, Brand bran)
        {

            using (var con = ConnectionFactory.GetConnection())
            {
                using (var tra = con.BeginTransaction())
                {
                    try
                    {
                        InsertModel(model, con, tra);
                        insertBrands(bran, con, tra);

                        tra.Commit();
                    }
                    catch (Exception)
                    {
                        tra.Rollback();
                        throw;
                    }

                }
            }
        }

        void InsertModel(Model model, IDbConnection conn, IDbTransaction tra)
        {

            try
            {
                conn.Execute(@" INSERT INTO Model (Name, BrandId)
                    VALUES(@Name, @BrandId)", new { Name = model.Name, BrandId = model.BrandId }, tra);
            }
            catch (Exception)
            {

                throw;
            }

        }

        void insertBrands(Brand brnd, IDbConnection conn, IDbTransaction tra)
        {
            try
            {
                conn.Execute(@" INSERT INTO Brand (Name)
                    VALUES(@Name)", new { Name = brnd.Name }, tra);
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
