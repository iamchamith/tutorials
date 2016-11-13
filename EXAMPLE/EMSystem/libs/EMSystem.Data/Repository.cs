using EMSystem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMSystem.Data.Helpers;
using Dapper;
using Dapper.Contrib.Extensions;

namespace EMSystem.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IList<T> All()
        {
            using (var con = ConnectionFactory.Connection)
            {
               return con.GetAll<T>().ToList();
            }
        }

        public void Delete(T employee)
        {
            using (var con = ConnectionFactory.Connection)
            {
                con.Delete<T>(employee);
            }
        }

        public T Get(int id)
        {
            using (var con = ConnectionFactory.Connection)
            {
                return con.Get<T>(id);
            }
        }

        public void Save(T employee)
        {
            using (var con = ConnectionFactory.Connection)
            {
                 con.Insert<T>(employee);
            }
        }

        public void Update(T employee)
        {
            using (var con = ConnectionFactory.Connection)
            {
                con.Update<T>(employee);
            }
        }
    }
}
