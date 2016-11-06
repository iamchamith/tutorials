using EF.DbService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Domain;
using System.Data.SqlClient;
using Utility.Exceptions;

namespace EF.DbService.Services
{
    public class StudentService :BaseService, IStudentRepo
    {
        public Student Create(Student item)
        {
            try
            {
                sms.Students.Add(item);
                sms.SaveChanges();
                return item;
            }
            catch (SqlException e) {

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

        public void Delete(int key)
        {
            try
            {
                var obj = sms.Students.FirstOrDefault(p => p.StudentId == key);
                if (obj == null)
                {
                    return;
                }
                var obj2 = sms.StudentsMore.FirstOrDefault(p => p.StudentId == key);
                sms.StudentsMore.Remove(obj2);
                sms.Students.Remove(obj);
                sms.SaveChanges();
            }
            catch (SqlException ex) {
                throw;
            }
            catch
            {
                throw;
            }
        }

        public List<Student> Read()
        {
            try
            {
                return sms.Students.OrderByDescending(p=>p.StudentId).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Student Read(int key)
        {
            try
            {
                var obj = sms.Students.FirstOrDefault(p => p.StudentId == key);
                if (obj==null)
                {
                    throw new ObjectNotFoundException();
                }
                return obj;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Student item, int key)
        {
            try
            {
                var obj = sms.Students.FirstOrDefault(p => p.StudentId == key);
                if (obj ==null)
                {
                    throw new ObjectNotFoundException();
                }
                obj.Dob = item.Dob;
                obj.Image = item.Image;
                obj.Name = item.Name;
                sms.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
