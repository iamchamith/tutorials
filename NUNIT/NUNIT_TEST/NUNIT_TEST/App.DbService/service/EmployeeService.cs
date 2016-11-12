using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DbService.interfaces;
using App.Domain;

namespace App.DbService.service
{
    public class EmployeeService : BaseService, IEmployee
    {
        public Employee Create(Employee item)
        {
            try
            {
                dba.Employees.Add(item);
                dba.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                dba.Employees.Remove(dba.Employees.FirstOrDefault(p => p.Id == id));
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IEnumerable<Employee> Read()
        {
            try
            {
                return dba.Employees.ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Employee Read(int id)
        {
            try
            {
                return dba.Employees.FirstOrDefault(p => p.Id == id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void Update(Employee item, int id)
        {
            try
            {
                var x = dba.Employees.FirstOrDefault(p => p.Id == id);
                x.Name = item.Name;
                x.Nic = item.Nic;
                x.Phone = item.Phone;
                dba.SaveChanges();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
