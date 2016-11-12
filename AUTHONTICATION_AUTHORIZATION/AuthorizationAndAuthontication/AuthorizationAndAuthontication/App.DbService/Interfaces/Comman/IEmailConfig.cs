using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Bo;
using App.DbService.Infrastructure;
using App.Domain;

namespace App.DbService.Interfaces.Comman
{
    interface IEmailConfig:  IRepository<EmailConfigBo, string>
    {
        EmailConfigBo SelectFirstOrDefault();
    }
}
