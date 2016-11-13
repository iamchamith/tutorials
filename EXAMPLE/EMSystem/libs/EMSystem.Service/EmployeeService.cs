using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMSystem.Core.Domain;
using EMSystem.Data;

namespace EMSystem.Service
{
    public class EmployeeService : IEmployeeService
    {
        IRepository<Employee> _repository;
        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public IList<Employee> All()
        {
            var employee =  _repository.All();
            return employee.AsQueryable()
                            .OrderBy(e => e.FirstName)
                            .ThenBy(e => e.LastName).ToList(); ;
        }

        public void DeleteById(int id)
        {
            var employee = new Employee { Id = id };
             _repository.Delete(employee);
        }

        public void Delete(Employee employee)
        {
            _repository.Delete(employee);
        }

        public Employee GetById(int id)
        {
            return _repository.Get(id);
        }

        public void Save(Employee employee)
        {
            _repository.Save(employee);
        }

        public void Update(Employee employee)
        {
            _repository.Update(employee);
        }
    }
}
