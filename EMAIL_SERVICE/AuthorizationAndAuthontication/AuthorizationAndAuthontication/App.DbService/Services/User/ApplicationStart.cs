using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Bo;

namespace App.DbService.Services.User
{
    public class ApplicationStart : BaseService
    {
        public List<RoleAccessBo> GetRoles()
        {
            try
            {
                return dba.RoleAccess.Select(x => AutoMapper.Mapper.Map<RoleAccessBo>(x)).ToList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
