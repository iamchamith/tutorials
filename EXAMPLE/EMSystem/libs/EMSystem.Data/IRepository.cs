using EMSystem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSystem.Data
{
    public interface IRepository<T> where T :class
    {
        IList<T> All();
        T Get(int id);
        void Update(T employee);
        void Delete(T employee);
        void Save(T employee);
    }
}
