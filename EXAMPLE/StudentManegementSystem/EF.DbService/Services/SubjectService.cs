using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.DbService.Interfaces;
using EF.Domain;
using System.Data.SqlClient;
using Utility.Exceptions;
using EF.DbService.Infrastructure;

namespace EF.DbService.Services
{
    public class SubjectService : BaseService, ISubjectRepo
    { 
        public Subject Create(Subject item)
        {
            try
            {
                sms.Subjects.Add(item);
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
                var obj = sms.Subjects.FirstOrDefault(p => p.SubjectId == key);
                if (obj == null)
                {
                    throw new ObjectNotFoundException("item not founded");
                }
                sms.Subjects.Remove(obj);
                sms.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public List<Subject> Read()
        {
            try
            {
                return sms.Subjects.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Subject Read(int key)
        {
            try
            {
                var obj = sms.Subjects.FirstOrDefault(p => p.SubjectId == key);
                if (obj == null)
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


        public void Update(Subject item, int key)
        {
            try
            {
                var obj = sms.Subjects.FirstOrDefault(p => p.SubjectId == key);
                if (obj == null)
                {
                    throw new ObjectNotFoundException();
                }
                obj.Fee = item.Fee;
                sms.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        List<ISubjectRepo> IRepository<ISubjectRepo, int>.Read()
        {
            throw new NotImplementedException();
        }

        ISubjectRepo IRepository<ISubjectRepo, int>.Read(int key)
        {
            throw new NotImplementedException();
        }
        public void Update(ISubjectRepo item, int key)
        {
            throw new NotImplementedException();
        }
        public ISubjectRepo Create(ISubjectRepo item)
        {
            throw new NotImplementedException();
        }
    }
}
