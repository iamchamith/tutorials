using EF.DbService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentManegementSystem.Controllers
{
    public class BaseController : ApiController
    {
        protected StudentMoreService studentMoreService;
        protected StudentSubjectService studentSubjectService;
        protected SubjectService subjectService;
        protected ErrorLogDbService errorLogDbService;
        protected StudentService studentService;
        protected SubjectModuleDbService subjectModuleServivice;
        public BaseController() {
            studentMoreService = new StudentMoreService();
            studentSubjectService = new StudentSubjectService();
            subjectService = new SubjectService();
            errorLogDbService = new ErrorLogDbService();
            studentService = new StudentService();
            subjectModuleServivice = new SubjectModuleDbService();
        }
    }
}
