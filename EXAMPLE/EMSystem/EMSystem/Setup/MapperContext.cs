using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using EMSystem.Core.Domain;
using EMSystem.Models;
using EMSystem.Helpers;
using EMSystem.Core.Enum;

namespace EMSystem.Setup
{
    public class MapperContext
    {
        public static MapperConfiguration Configure()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<Employee, EmployeeViewModel>().ForMember(
                    des => des.FullName, opt => opt.MapFrom(
                        src => $"{src.Title}.{src.FirstName.ToTitleCase()} {src.LastName.ToTitleCase()}"))
                        .ForMember(
                    des => des.FirstName, opt => opt.MapFrom(src => src.FirstName.ToTitleCase()))
                        .ForMember(
                    des => des.LastName, opt => opt.MapFrom(src => src.LastName.ToTitleCase()))
                        .ForMember(
                    des => des.Period, opt => opt.MapFrom(src => src.DateOfJoin.Period(DateTime.Now)))
                        .ForMember(
                    des => des.Salary, opt => opt.MapFrom(src => src.Salary.ToString("c")));

                config.CreateMap<EmployeeViewModel, Employee>().ForMember(
                    des => des.Salary, opt => opt.MapFrom(src => HelperExtensions.CurrencyToDecimal(src.Salary)));

                config.CreateMap<Employee, EmployeeEditViewModel>().ForMember(
                    des => des.FullName, opt => opt.MapFrom(
                        src => $"{src.Title}.{src.FirstName.ToTitleCase()} {src.LastName.ToTitleCase()}"))
                        .ForMember(
                    des => des.Period, opt => opt.MapFrom(src => src.DateOfJoin.Period(DateTime.Now)))
                        .ForMember(
                   des => des.Position, opt => opt.MapFrom(src => src.Position.ParseEnum<Position>()))
                        .ForMember(
                   des => des.Division, opt => opt.MapFrom(src => src.Division.ParseEnum<Division>()))
                        .ForMember(
                   des => des.TitleOfEmployee, opt => opt.MapFrom(src => src.Title.ParseEnum<Title>()))
                        .ForMember(
                   des => des.Office, opt => opt.MapFrom(src => src.Office.ParseEnum<Office>()));

                config.CreateMap<EmployeeEditViewModel, Employee>().ForMember(
                  des => des.Position, opt => opt.MapFrom(src => src.Position.ToString()))
                       .ForMember(
                  des => des.Division, opt => opt.MapFrom(src => src.Division.ToString()))
                       .ForMember(
                  des => des.Title, opt => opt.MapFrom(src => src.TitleOfEmployee.ToString()))
                       .ForMember(
                  des => des.Office, opt => opt.MapFrom(src => src.Office.ToString()))
                        .ForMember(
                  des => des.Salary, opt => opt.MapFrom(src => HelperExtensions.CurrencyToDecimal(src.Salary)));

            });
            return configuration;
        }
    }



}