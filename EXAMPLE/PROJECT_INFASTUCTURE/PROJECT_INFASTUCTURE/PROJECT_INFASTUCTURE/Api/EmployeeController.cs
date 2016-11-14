using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PROJECT_INFASTUCTURE.Models;
using AutoMapper;
using App.Bo;
using App.DbService.Services;
using App.DbService.Interfaces;

namespace PROJECT_INFASTUCTURE.Api
{
    public class EmployeeController : BaseApiController
    {
        IEmployeeService empService; 
        public EmployeeController() {
            this.empService = new EmployeeDbService();
        }

        public EmployeeController(IEmployeeService empServicep)
        {
            this.empService = empServicep;
        }

        [HttpPost]
        public ActionDetail Create(EmployeeViewModel item)
        {
            try
            {
                return Actions.Success(empService.Create(Mapper.Map<EmployeeBo>(item)));
            }
            catch (Exception ex)
            {
                return Actions.Error(ex);
            }
        }
        [HttpPost]
        public ActionDetail Update(EmployeeViewModel item, int key)
        {
            try
            {
                empService.Update(Mapper.Map<EmployeeBo>(item), key);
                return Actions.Success();
            }
            catch (Exception ex)
            {
                return Actions.Error(ex);
            }
        }
        [HttpDelete]
        public ActionDetail Delete(int key)
        {
            try
            {
                empService.Delete(key);
                return Actions.Success();
            }
            catch (Exception ex)
            {
                return Actions.Error(ex);
            }
        }
        [HttpGet]
        public ActionDetail Read()
        {
            try
            {
                return Actions.Success(empService.Read().Select(x=>Mapper.Map<EmployeeViewModel>(x)).ToList());
            }
            catch (Exception ex)
            {
                return Actions.Error(ex);
            }
        }
        [HttpGet]
        public ActionDetail Read(int key)
        {
            try
            {
                return Actions.Success(Mapper.Map<EmployeeViewModel>(empService.Read(key)));
            }
            catch (Exception ex)
            {
                return Actions.Error(ex);
            }
        }
        [HttpGet]
        public ActionDetail Search(string q)
        {
            try
            {
                return Actions.Success(empService.Search(q).Select(x => Mapper.Map<EmployeeViewModel>(x)).ToList());
            }
            catch (Exception ex)
            {
                return Actions.Error(ex);
            }
        }
    }
}
