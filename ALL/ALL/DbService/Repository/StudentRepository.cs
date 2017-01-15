using DbService.Infrastructure;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DbService.Repository
{
    public interface IStudentRepository : IRepository<Student>
    {
        int RecodeCount();
    }
    public class StudentRepository : IStudentRepository
    {
        private IUnitOfWork unitOfWork = new UnitOfWork();

        public StudentRepository(IUnitOfWork _unitOfWork)
        {

            this.unitOfWork = _unitOfWork;
        }

        public void Delete(Student entityToDelete)
        {
            try
            {
                unitOfWork.StudentRepository.Delete(entityToDelete);
                unitOfWork.Save();
            }
            catch
            {
                throw;
            }
        }

        public void Delete(object id)
        {
            try
            {
                unitOfWork.StudentRepository.Delete(id);
                unitOfWork.Save();
            }
            catch
            {
                throw;
            }
        }
  
        public Student GetByID(object id)
        {
            try
            {
                return unitOfWork.StudentRepository.GetByID(id);
            }
            catch
            {
                throw;
            }
        }

        public void Insert(Student entity)
        {
            try
            {
                unitOfWork.StudentRepository.Insert(entity);
                unitOfWork.Save();
            }
            catch
            {
                throw;
            }
        }

        public void Update(Student entityToUpdate)
        {
            try
            {
                unitOfWork.StudentRepository.Update(entityToUpdate);
                unitOfWork.Save();
            }
            catch
            {
                throw;
            }
        }


        public int RecodeCount()
        {
            try
            {
                return unitOfWork.Context.Students.ToList().Count;
            }
            catch { throw; }
        }

        public IEnumerable<Student> Get(Expression<Func<Student, bool>> filter = null, Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null, string includeProperties = "")
        {
            try
            {
                return unitOfWork.StudentRepository.Get(filter, orderBy, includeProperties);
            }
            catch
            {
                throw;
            }
        }
    }
}
