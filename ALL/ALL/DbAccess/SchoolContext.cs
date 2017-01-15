using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess
{
    public class SchoolContext:DbContext
    {
        public SchoolContext() : base(@"Data Source=DELL\SQLEXPRESS;Initial Catalog=WebApiAll;Integrated Security=True;Pooling=False") { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }

    }
}
