using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Bo;
using App.DbService.Infrastructure;
using App.Domain;

namespace App.DbService.Interfaces.User
{
    public interface IUser : IRepository<UserBo,string>
    {
        GCUserSession LoginUser(UserBo item);

        void Register(UserBo item, string userType);
        string ValidateEmailTokenUpdate(string email);
        void ValidateEmailSendEmail(string email, string token, EmailConfigBo sender);
        void VerifyEmailTokenValidate(string email, string token);

        string ForgetPasswordTokenRequest(string email);
        void ForgetPasswordSendEmail(string email, string token, EmailConfigBo sender);
        void ForgetPasswordTokenValidate(string email, string token);
        void ForgetPasswordCreateNewPassword(string email,string newPassword);

        void ChangePassword(UserBo item, string newPassword);
        void UpdateUser(UserBo item);

        void ReadUser(string userid);
        List<UserBo> ReadUser();

        List<RoleAccessBo> GetRoleTags();

        List<RoleBo> GetSystemRoles();
    }
}
