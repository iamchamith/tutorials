using EF.DbService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Domain;
using System.Data.SqlClient;
using Utility.Exceptions;
using EF.DbService.Infrastructure;

namespace EF.DbService.Services
{
    public class StudentSubjectService : BaseService, IStudentSubjectRepo
    {
        public void Create(int studentId,List<int> subjectIds)
        {
            try
            {
                Delete(studentId);
                var studentSubject = new List<StudentSubject>();
                for (int i = 0; i < studentId; i++)
                {
                   sms.StudentSubjects.Add(new StudentSubject {
                       RegDate = DateTime.Today,
                       SubjectId = i,
                       StudentId = studentId
                   });
                }
                sms.SaveChanges();
            }
            catch (SqlException e)
            {

                if (e.Number == 2601)
                {
                    throw new PrimaryKeyDuplicateException("student already registed");
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

       
        public void Delete(int studentId)
        {
            try
            {
                var obj = sms.StudentSubjects.Where(p => p.StudentId == studentId);
                sms.StudentSubjects.RemoveRange(obj);
                sms.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

      

        public List<Subject> Read(Student item)
        {
            try
            {
                var obj = from a in sms.Subjects
                          join b in sms.StudentSubjects on a.SubjectId equals b.SubjectId
                          where b.StudentId == item.StudentId
                          select new { a.Fee, a.Name, a.SubjectId,b.RegDate };

                var result = new List<Subject>();
                foreach (var val in obj)
                {
                    result.Add(new Subject { Fee = val.Fee, Name = val.Name, SubjectId = val.SubjectId, RegDate = val.RegDate });
                }
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Student> Read(Subject item)
        {
            try
            {
                var obj = from a in sms.Students
                          join b in sms.StudentSubjects on a.StudentId equals b.SubjectId
                          select new { a.StudentId, a.Image, a.Name,a.Email };

                var result = new List<Student>();
                foreach (var val in obj)
                {
                    result.Add(new Student { Email = val.Email, Name = val.Name, StudentId = val.StudentId });
                }
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }
         
        public void Update(StudentSubject item, int key)
        {
            throw new NotImplementedException();
        }
         
        List<StudentSubject> IRepository<StudentSubject, int>.Read()
        {
            throw new NotImplementedException();
        }

        List<Student> IStudentSubjectRepo.Read(Subject item)
        {
            throw new NotImplementedException();
        }

        List<Subject> IStudentSubjectRepo.Read(Student item)
        {
            throw new NotImplementedException();
        }

        StudentSubject IRepository<StudentSubject, int>.Read(int key)
        {
            throw new NotImplementedException();
        }
        public List<StudentMore> Read()
        {
            throw new NotImplementedException();
        }
       
        public StudentSubject Create(StudentSubject item)
        {
            throw new NotImplementedException();
        }
    }
}
