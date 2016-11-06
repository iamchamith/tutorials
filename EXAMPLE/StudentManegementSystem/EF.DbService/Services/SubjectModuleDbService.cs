using EF.DbService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Domain;
using EF.DbService.Infrastructure;

namespace EF.DbService.Services
{
    public class SubjectModuleDbService : BaseService, ISubjectModuleRepo
    {

        public void Create(List<SubjectModules> items)
        {
            try
            {
                sms.SubjectModules.AddRange(items);
                sms.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Delete(int subjectId)
        {
            try
            {
                var obj = sms.SubjectModules.Where(p => p.SubjectId == subjectId).ToList();
                sms.SubjectModules.RemoveRange(obj);
                sms.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        public List<string> Read(int subjectId)
        {
            try
            {
                var res = new List<string>();
                foreach (var item in sms.SubjectModules.Where(p => p.SubjectId == subjectId).ToList())
                {
                    res.Add(item.ModuleName);
                }
                return res;
            }
            catch
            {
                throw;
            }
        }
        public void Update(List<SubjectModules> items, int subjectId)
        {
            try
            {
                Delete(subjectId);
                Create(items);
            }
            catch
            {
                throw;
            }
        }

        public void Update(SubjectModules item, int key)
        {
            throw new NotImplementedException();
        }

        SubjectModules IRepository<SubjectModules, int>.Read(int key)
        {
            throw new NotImplementedException();
        }
        public List<SubjectModules> Read()
        {
            throw new NotImplementedException();
        }
        public SubjectModules Create(SubjectModules item)
        {
            throw new NotImplementedException();
        }
    }
}
