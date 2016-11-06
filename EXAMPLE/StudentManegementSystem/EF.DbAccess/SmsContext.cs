using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EF.Domain;
namespace EF.DbAccess
{
    public class SmsContext : DbContext
    {
        public SmsContext() : base(@"Data Source=DELL\SQLEXPRESS;Initial Catalog=SMS2;Integrated Security=True;Pooling=False") { }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentMore> StudentsMore { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<SubjectModules> SubjectModules { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Error> Errors { get; set; }
    }
}
