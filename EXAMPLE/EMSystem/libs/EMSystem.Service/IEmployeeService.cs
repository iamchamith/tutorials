using EMSystem.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSystem.Service
{
    public interface IEmployeeService
    {
        IList<Employee> All();
        Employee GetById(int id);
        void Update(Employee employee);
        void DeleteById(int id);
        void Delete(Employee employee);
        void Save(Employee employee);
    }
}
