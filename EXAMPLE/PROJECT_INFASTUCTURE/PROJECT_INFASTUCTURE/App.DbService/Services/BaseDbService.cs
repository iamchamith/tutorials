using App.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DbService.Services
{
   
    public class BaseDbService
    {
        protected EMSDbContext dba;
        public BaseDbService() {
            dba = new EMSDbContext();
        }
    }
}
