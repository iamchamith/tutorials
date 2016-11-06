using EF.DbService.Infrastructure;
using EF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.DbService.Interfaces
{
    public interface IStudentSubjectRepo : IRepository<StudentSubject, int>
    {
        new void Delete(int studentId);
        List<Subject> Read(Student item);
        List<Student> Read(Subject item);
        new void Create(int studentId, List<int> subjectIds);

    }
}
