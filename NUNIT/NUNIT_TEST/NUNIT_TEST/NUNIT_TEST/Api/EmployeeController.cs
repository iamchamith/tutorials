using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using App.DbService.service;
using App.Domain;
using App.DbService.interfaces;

namespace NUNIT_TEST.Api
{
    public class EmployeeController : ApiController
    {
        private IEmployee conn;
         
        public EmployeeController(IEmployee emp) {
            this.conn = emp;
        }
        public EmployeeController()
        {
            this.conn = new EmployeeService();
        }
        public Employee Create(Employee item)
        {
            try
            {
                return conn.Create(item);
            }
            catch (Exception)
            {
                return new Employee();
            }
        }

        public bool Update(Employee item, int key)
        {
            try
            {
                conn.Update(item, key);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int key)
        {
            try
            {
                conn.Delete(key);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<Employee> Select()
        {
            try
            {
                return conn.Read();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Employee Select(int key)
        {
            try
            {
                return conn.Read(key);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}