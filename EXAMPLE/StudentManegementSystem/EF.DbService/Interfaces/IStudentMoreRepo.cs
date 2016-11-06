using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.DbService.Infrastructure;
using EF.Domain;

namespace EF.DbService.Interfaces
{
    public interface IStudentMoreRepo: IRepository<StudentMore,int>
    {

    }
}
