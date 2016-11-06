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
    public class StudentMoreService : BaseService, IStudentMoreRepo
    {
        public StudentMore Create(StudentMore item)
        {
            try
            {
                sms.StudentsMore.Add(item);
                sms.SaveChanges();
                return item;
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

        public void Delete(int key)
        {
            try
            {
                var obj = sms.StudentsMore.FirstOrDefault(p => p.StudentId == key);
                if (obj == null)
                {
                    return;
                }
                sms.StudentsMore.Remove(obj);
                sms.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<StudentMore> Read()
        {
            throw new NotImplementedException();
        }

        public StudentMore Read(int key)
        {
            try
            {
                var obj = sms.StudentsMore.FirstOrDefault(p => p.StudentId == key);
                if (obj == null)
                {
                    return new StudentMore();
                }
                return obj;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(StudentMore item, int key)
        {
            try
            {
                var obj = sms.StudentsMore.Where(p => p.StudentId == key).FirstOrDefault();
                if (obj.StudentId == null)
                {
                    item.StudentId = key;
                    Create(item);
                }
                obj.Address = item.Address;
                obj.PhoneNumber = item.PhoneNumber;
                obj.School = item.School;
                sms.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
