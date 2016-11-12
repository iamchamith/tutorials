using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Bo;
using App.Bo.Enums;
using App.DbService.Interfaces.User;
using App.Domain;
using App.Util.EmailService.Service;
using App.Util.EmailService.ViewModel;
using App.Util.Exceptions;
using AutoMapper;

namespace App.DbService.Services.User
{
    public class UserService : BaseService, IUser
    {
        public void ChangePassword(UserBo item, string newPassword)
        {
            try
            {
                var obj = dba.Users_.FirstOrDefault(p => p.Password == item.Password && p.Email == item.Email);
                if (obj == null)
                {
                    throw new InvaliedUserLoginInfomationException("user not founded");
                }
                obj.Password = newPassword;
                dba.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ForgetPasswordCreateNewPassword(string email, string newPassword)
        {
            try
            {
                var obj = dba.Users_.FirstOrDefault(p => p.Email == email);
                if (obj == null)
                {
                    throw new InvaliedUserLoginInfomationException("user not founded");
                }
                obj.Password = newPassword;
                dba.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public string ForgetPasswordTokenRequest(string email)
        {
            try
            {
                var token = Guid.NewGuid().ToString();
                var item = dba.UserTokens.FirstOrDefault(p => p.Email == email && p.TokenType == (int)EmailType.ForgetPassword);
                if (item == null)
                {
                    dba.UserTokens.Add(new UserToken
                    {
                        Email = email,
                        TokenType = (int)EmailType.ForgetPassword,
                        CreatedTime = DateTime.Now,
                        IsChecked = false,
                        Token = token
                    });
                }
                else
                {
                    item.Token = token;
                    item.CreatedTime = DateTime.Now;
                }
                dba.SaveChanges();
                return token;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ForgetPasswordTokenValidate(string email, string token)
        {
            try
            {
                var obj = dba.UserTokens.FirstOrDefault(
                    p => p.Email == email && p.TokenType == (int)EmailType.ForgetPassword && p.Token == token && p.IsChecked == false);
                if (obj == null)
                {
                    throw new InvaliedUserLoginInfomationException("user not founded");
                }
                obj.IsChecked = true;
                dba.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public GCUserSession LoginUser(UserBo item)
        {
            try
            {
                var obj = (from c1 in dba.Users_
                           where c1.Email == item.Email && c1.Password == item.Password 
                           select new
                           {
                               userId = c1.UserId,
                               roleId = c1.RoleId,
                               name = c1.Name,
                               ValidateEmail = c1.ValidateEmail 
                           }).FirstOrDefault();
                if (obj == null)
                {
                    throw new InvaliedUserLoginInfomationException("user not founded");
                }
                if (!obj.ValidateEmail)
                {
                    throw new EmailAddressNotValidateException();
                }
                return new GCUserSession
                {
                    Email = item.Email,
                    UserId = obj.userId,
                    Name = obj.name,
                    UserType = (int)UserRole(obj.roleId.Trim())
                };

            }
            catch (Exception)
            {
                throw;
            }
        }
         
        public List<UserBo> ReadUser()
        {
            try
            {
                return dba.Users_.ToList().Select(AutoMapper.Mapper.Map<UserBo>).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserBo ReadUser(string userid)
        {
            try
            {
                var item = dba.Users_.FirstOrDefault(p => p.UserId == userid);
                if (item == null)
                {
                    throw new ItemNotFoundException("user not founded");
                }
                return Mapper.Map<UserBo>(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Register(UserBo item,string userType)
        {
            try
            {
                if (dba.Users_.Count(p => p.Email == item.Email) != 0)
                {
                    throw new PrimaryKeyVialationException("user is already registed");
                }
                string userId = Guid.NewGuid().ToString();
                dba.Users_.Add(new Domain.Users
                {
                    Email = item.Email,
                    Password = item.Password,
                    UserId = userId,
                    Active = false,
                    ValidateEmail = false,
                    Name = item.Name,
                    RoleId = userType
                });
               
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateUser(UserBo item)
        {
            try
            {
                var obj = dba.Users_.FirstOrDefault(p => p.UserId == item.UserId);
                if (obj == null)
                {
                    throw new ItemNotFoundException("user not founded");
                }
                obj.Name = item.Name;
                dba.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }
        public string ValidateEmailTokenUpdate(string email)
        {
            try
            {
                string token = Guid.NewGuid().ToString();
                var item = dba.UserTokens.FirstOrDefault(p => p.Email == email && p.TokenType == (int)EmailType.Registration);
                if (item == null)
                {
                    dba.UserTokens.Add(new UserToken
                    {
                        Email = email,
                        TokenType = (int)EmailType.Registration,
                        CreatedTime = DateTime.Now,
                        IsChecked = false,
                        Token = token
                    });
                }
                else
                {
                    item.Token = token;
                    item.CreatedTime = DateTime.Now;
                }
                dba.SaveChanges();
                return token;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void VerifyEmailTokenValidate(string email, string token)
        {
            try
            {
                var obj = dba.UserTokens.FirstOrDefault(
                    p => p.Email == email && p.TokenType == (int)EmailType.Registration && p.Token == token && p.IsChecked == false);

                if (obj == null)
                {
                    throw new ItemNotFoundException("user not founded");
                }
                obj.IsChecked = true;

                var obj2 = dba.Users_.FirstOrDefault(p => p.Email == email);
                if (obj2 == null)
                {
                    throw new ItemNotFoundException("user not founded");
                }
                obj2.ValidateEmail = true;
                obj2.Active = true;
                dba.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }


        #region emails
        public void ValidateEmailSendEmail(string email, string token, EmailConfigBo sender)
        {
            EmailService.WithTemplate(EmailType.Registration).Send(new RegisterEmailViewModel
            {
                Emails = new List<string>() { email },
                Link = token,
                ReseverName = "User "
            }, sender);
    
        }
        public void ForgetPasswordSendEmail(string email, string token, EmailConfigBo sender)
        {
            EmailService.WithTemplate(EmailType.ForgetPassword).Send(new RegisterEmailViewModel
            {
                Emails = new List<string>() { email },
                Link = token,
                ReseverName = "User "
            }, sender);
        }

        #endregion


     

        private EUserType UserRole(string role)
        {
            if (role.Equals("Admin"))
            {
                return EUserType.Admin;
            }
            else if (role.Equals("Citizen"))
            {
                return EUserType.Citizen;
            }
            else if (role.Equals("Staff"))
            {
                return EUserType.Staff;
            }
            else
            {
                return EUserType.Guest;
            }
        }

        public List<RoleAccessBo> GetRoleTags()
        {
            var lst = new List<RoleAccessBo>();
            foreach (var items in dba.RoleAccess.ToList())
            {
                lst.Add(new RoleAccessBo()
                {
                    RoleId = UserRole(items.RoleId),
                    Tag = items.Tag

                });
            }
            return lst;
        }

        public List<RoleBo> GetSystemRoles()
        {
            try
            {
                var lst = dba.Roles.ToList();
                return lst.Select(x => AutoMapper.Mapper.Map<RoleBo>(x)).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #region overrided
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
        public UserBo Select(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserBo item, string id)
        {
            throw new NotImplementedException();
        }
        public List<UserBo> Select()
        {
            throw new NotImplementedException();
        }
        public UserBo Create(UserBo item)
        {
            throw new NotImplementedException();
        }

        void IUser.ReadUser(string userid)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
