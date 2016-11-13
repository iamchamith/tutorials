using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using App.Bo;
using App.Domain;
using PROJECT_INFASTUCTURE.Models;

namespace PROJECT_INFASTUCTURE.App_Start
{
    public class AutomapperConfig
    {
        public AutomapperConfig() {

            Mapper.CreateMap<EmployeeBo,Employee>();
            Mapper.CreateMap<Employee, EmployeeBo>();

            Mapper.CreateMap<EmployeeBo, EmployeeViewModel>();
            Mapper.CreateMap<EmployeeViewModel, EmployeeBo>();

        }
    }
}