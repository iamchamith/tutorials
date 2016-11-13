using App.Bo;
using App.DbService.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbService.Interfaces
{
    public interface IEmployeeService: IRepository<EmployeeBo,int>
    {
        IEnumerable<EmployeeBo> Search(string q);
    }
}
