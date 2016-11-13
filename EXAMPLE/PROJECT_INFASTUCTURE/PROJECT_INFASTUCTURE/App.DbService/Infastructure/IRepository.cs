using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbService.Infastructure
{
    public interface IRepository<T, Tkey> where T : class
    {
        T Create(T item);
        void Update(T item, Tkey key);
        void Delete(Tkey key);
        T Read(Tkey key);
        IEnumerable<T> Read();
    }
}
