using EF.DbService.Infrastructure;
using EF.DbService.Interfaces;
using EF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DbService.Interfaces
{
    public interface ISubjectModuleRepo:IRepository<SubjectModules,int>
    {
        void Create(List<SubjectModules> items);
        void Update(List<SubjectModules> items, int subjectId);
        List<string> Read(int subjectId);
    }
}
