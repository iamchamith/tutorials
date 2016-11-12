using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbService.infastucture
{
    public interface IRepository<T, TKey> where T : class
    {
        T Create(T item);
        void Update(T item, TKey id);
        void Delete(TKey id);
        T Read(TKey id);
        IEnumerable<T> Read();

    }
}
