using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbService.Infrastructure
{
    public interface IRepository<T, in TKey> where T : class
    {
        T Create(T item);
        void Update(T item, TKey id);
        void Delete(TKey id);
        T Select(TKey id);
        List<T> Select();
    }
}
