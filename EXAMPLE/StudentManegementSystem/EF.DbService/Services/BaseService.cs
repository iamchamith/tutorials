using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.DbAccess;
namespace EF.DbService.Services
{
    public class BaseService
    {
        protected SmsContext sms = null;
        public BaseService() {
            sms = new SmsContext();
        }
    }
}
