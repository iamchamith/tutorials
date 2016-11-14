using App.DbService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Bo;
using App.Domain;
using AutoMapper;
using App.Util.Exceptions;

namespace App.DbService.Services
{
    public class EmployeeDbService : BaseDbService, IEmployeeService
    {
        public EmployeeBo Create(EmployeeBo item)
        {
            try
            {
                item.RegDate = DateTime.Now;
                Employee obj = Mapper.Map<Employee>(item);
                dba.Employees.Add(obj);
                dba.SaveChanges();
                return Mapper.Map<EmployeeBo>(obj);
            }
            catch
            {
                throw;
            }
        }

        public void Delete(int key)
        {
            try
            {
                var obj = dba.Employees.SingleOrDefault(p => p.Id == key);
                if (obj == null)
                {
                    throw new ObjectNotFoundException("Employee not founded");
                }
                dba.Employees.Remove(obj);
                dba.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<EmployeeBo> Read()
        {
            try
            {
                return dba.Employees.OrderByDescending(p=>p.Id).ToList().Select(x => Mapper.Map<EmployeeBo>(x)).ToList();
            }
            catch
            {

                throw;
            }
        }

        public EmployeeBo Read(int key)
        {
            try
            {
                var obj = dba.Employees.FirstOrDefault(p => p.Id == key);
                if (obj == null)
                {
                    throw new ObjectNotFoundException("Employee not founded");

                }
                return Mapper.Map<EmployeeBo>(obj);
            }
            catch
            {

                throw;
            }
        }

        public IEnumerable<EmployeeBo> Search(string q)
        {
            try
            {
                return dba.Employees.Where(p=>p.Name.ToLower().StartsWith(q.ToLower())).ToList().Select(x => Mapper.Map<EmployeeBo>(x)).ToList();
            }
            catch
            {
                throw;
            }
        }

        public void Update(EmployeeBo item, int key)
        {
            try
            {
                var obj = dba.Employees.SingleOrDefault(p => p.Id == key);
                if (obj == null)
                {
                    throw new ObjectNotFoundException("Employee not founded");
                }
                obj.Name = item.Name;
                obj.Phone = item.Phone;
                obj.Email = item.Email;
                dba.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
