using AutoMapper;
using EF.Domain;
using StudentManegementSystem.Models;
using StudentManegementSystem.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Utility.Exceptions;

namespace StudentManegementSystem.Controllers
{
    //crud
    [System.Web.Http.RoutePrefix("api/Student")]
    public class StudentController : BaseController
    {
        // GET api/Student/StudentRead
        [CompressContent]
        [HttpGet]
        public ActionResult StudentRead()
        {
            try
            {
                return ActionResultProcess.Success(studentService.Read().Select(x => AutoMapper.Mapper.Map<StudentViewModel>(x)).ToList());
            }
            catch (Exception ex)
            {
                return ActionResultProcess.Error(ex);
            }
        }
        [CompressContent]
        [HttpGet]
        public ActionResult StudentReadSingle(int id)
        {
            try
            {
                var result = new StudentViewViewModel()
                {
                    Student = Mapper.Map<StudentViewModel>(studentService.Read(id)),
                    StudentMore = Mapper.Map<StudentMoreViewModel>(studentMoreService.Read(id))
                };

                return ActionResultProcess.Success(result);
            }
            catch (Exception ex)
            {
                return ActionResultProcess.Error(ex);
            }
        }

        // POST api/Student/StudentCreate
        [HttpPost]
        public ActionResult StudentCreate(StudentViewViewModel item)
        {
            try
            {
                Student s = studentService.Create(Mapper.Map<Student>(item.Student));
                StudentMoreViewModel studentMore = item.StudentMore;
                studentMore.StudentId = s.StudentId;
                studentMoreService.Create(Mapper.Map<StudentMore>(item.StudentMore));
                return ActionResultProcess.Success();
            }
            catch (Exception ex)
            {
                return ActionResultProcess.Error(ex);
            }
        }

        [HttpPost]
        public ActionResult StudentUpdate(StudentViewViewModel item)
        {
            try
            {
                studentService.Update(Mapper.Map<Student>(item.Student), item.Student.StudentId);
                studentMoreService.Update(Mapper.Map<StudentMore>(item.StudentMore), item.Student.StudentId);
                return ActionResultProcess.Success();
            }
            catch (Exception ex)
            {
                return ActionResultProcess.Error(ex);
            }
        }

        [HttpPost]
        public ActionResult StudentDelete(StudentViewModel item)
        {
            try
            {
                studentService.Delete(item.StudentId);
                studentMoreService.Delete(item.StudentId);
                return ActionResultProcess.Success();
            }
            catch (Exception ex)
            {
                return ActionResultProcess.Error(ex);
            }
        }

        [HttpPost]
        public ActionResult FileUpload(IEnumerable<HttpPostedFileBase> files)
        {
            try
            {
                if (files != null)
                {
                    var file = files.FirstOrDefault();
                    string pic = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(file.FileName);
                    string path = System.IO.Path.Combine(
                                           HttpContext.Current.Server.MapPath("~/images/profile"), pic);
                    file.SaveAs(path);
                    return ActionResultProcess.Success(pic);
                }
                else
                {
                    throw new ObjectNotFoundException("image not founded");
                }
            }
            catch (Exception ex)
            {
                return ActionResultProcess.Error(ex);
            }
        }
        // POST api/Student/SaveImage
        [HttpPost]
        public System.Web.Mvc.ActionResult SaveImage(IEnumerable<HttpPostedFileBase> files)
        {
            // The Name of the Upload component is "files"
            if (files != null)
            {
                foreach (var file in files)
                {
                    // Some browsers send file names with full path. This needs to be stripped.
                    //var fileName = Path.GetFileName(file.FileName);
                    //var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    // The files are not actually saved in this demo
                    // file.SaveAs(physicalPath);
                }
            }

            // Return an empty string to signify success
            return null;
        }
        // POST api/Subject/RemoveImage
        public IHttpActionResult RemoveImage(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    // var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    // TODO: Verify user permissions

                    //if (System.IO.File.Exists(physicalPath))
                    //{
                    //    // The files are not actually removed in this demo
                    //    // System.IO.File.Delete(physicalPath);
                    //}
                }
            }

            // Return an empty string to signify success
            return null;
        }
        #region <student subject>
        [HttpGet]
        public ActionResult StudentSubjectList(int studentId)
        {

            try
            {
                return ActionResultProcess.Success(studentSubjectService.Read(new Student { StudentId = studentId }).Select(x => AutoMapper.Mapper.Map<StudentSubjectViewModel>(x)).ToList());
            }
            catch (Exception ex)
            {
                return ActionResultProcess.Error(ex);
            }
        }

        [HttpPost]
        public ActionResult AddStudentSubject(int studentId,List<int> subjectId) {
            try
            {
                studentSubjectService.Create(studentId, subjectId);
                return ActionResultProcess.Success();
            }
            catch (Exception ex)
            {

                return ActionResultProcess.Error(ex);
            }
        }

        [HttpPost]
        public ActionResult RemoveStudentSubject(int studentId, int subjectId) { return null; }
        #endregion
    }
}
