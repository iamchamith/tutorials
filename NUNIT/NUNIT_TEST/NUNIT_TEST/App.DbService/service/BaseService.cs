using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DbAccess;

namespace App.DbService.service
{
    public class BaseService
    {
        protected PlutoContext dba; 
        public BaseService()
        {
            dba = new PlutoContext();
        }
    }
}
