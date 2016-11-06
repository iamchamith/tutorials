using AutoMapper;
using EF.Domain;
using StudentManegementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManegementSystem.App_Start
{
    public class AutomapperConfig
    {
        public AutomapperConfig() {
            Mapper.CreateMap<Student, StudentViewModel>();
            Mapper.CreateMap<StudentViewModel, Student>();

            Mapper.CreateMap<StudentMore, StudentMoreViewModel>();
            Mapper.CreateMap<StudentMoreViewModel, StudentMore>();

            Mapper.CreateMap<Subject, SubjectViewModel>();
            Mapper.CreateMap<SubjectViewModel, Subject>();

            Mapper.CreateMap<SubjectModules, SubjectModulesViewModel>();
            Mapper.CreateMap<SubjectModulesViewModel, SubjectModules>();

            Mapper.CreateMap<StudentSubjectViewModel, StudentSubject>();
            Mapper.CreateMap<StudentSubject, StudentSubjectViewModel>();

            Mapper.CreateMap<StudentSubjectViewModel, Subject>();
            Mapper.CreateMap<Subject, StudentSubjectViewModel>();
        }
    }
}