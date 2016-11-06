using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DbService.Infrastructure
{
    public interface IRepository<T,Key> where T:class
    {
        T Create(T item);
        List<T> Read();
        T Read(Key key);
        void Delete(Key key);
        void Update(T item, Key key);
    }
}
