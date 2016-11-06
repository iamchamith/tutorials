using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbService.infrastructure
{
    public interface IRepositoty<T,TKey> where T : class
    {
        T Create(T item);
        void Update(T item);
        void Delete(TKey key);
        List<T> Select();
        T Select(TKey key);
    }
}
