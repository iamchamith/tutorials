using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Bo;
using App.DbService.Interfaces.Comman;
using App.Domain;
using AutoMapper;

namespace App.DbService.Services.Comman
{
    public class EmailConfigService : BaseService, IEmailConfig
    {
        public EmailConfigBo SelectFirstOrDefault()
        {
            try
            {
                return Mapper.Map<EmailConfigBo>(dba.EmailConfigs.FirstOrDefault());
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region <not used>
        public EmailConfigBo Create(EmailConfigBo item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<EmailConfigBo> Select()
        {
            throw new NotImplementedException();
        }

        public EmailConfigBo Select(string id)
        {
            throw new NotImplementedException();
        }


        public void Update(EmailConfigBo item, string id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
