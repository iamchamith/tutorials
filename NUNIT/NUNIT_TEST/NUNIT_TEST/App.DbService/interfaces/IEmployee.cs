using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DbService.infastucture;
using App.Domain;

namespace App.DbService.interfaces
{
    public interface IEmployee : IRepository<Employee, int>
    {
    }
}
