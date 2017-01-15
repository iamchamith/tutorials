using DbAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbService.Infrastructure
{
    public interface IUnitOfWork
    {
        GenericRepository<Student> StudentRepository { get; }
        GenericRepository<Subject> SubjectRepository { get; }
        void Save();
        SchoolContext Context { get;}
         
    }
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private SchoolContext context = new SchoolContext();
        private GenericRepository<Student> studentRepository;
        private GenericRepository<Subject> subjectRepository;

        public SchoolContext Context
        {
            get
            {
                return context;
            }
        }
        public GenericRepository<Student> StudentRepository
        {
            get
            {

                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(context);
                }
                return studentRepository;
            }
        }
        public GenericRepository<Subject> SubjectRepository
        {
            get
            {

                if (this.subjectRepository == null)
                {
                    this.subjectRepository = new GenericRepository<Subject>(context);
                }
                return subjectRepository;
            }
        }
         
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
