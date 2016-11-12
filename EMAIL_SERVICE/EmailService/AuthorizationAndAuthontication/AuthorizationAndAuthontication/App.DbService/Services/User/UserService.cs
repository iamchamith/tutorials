using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Bo;
using App.Bo.Enums;
using App.DbService.Interfaces.User;
using App.Domain;
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
                var obj = dba.Users.FirstOrDefault(p => p.Password == item.Password && p.Email == item.Email);
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
                var obj = dba.Users.FirstOrDefault(p => p.Email == email);
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
                var obj = (from c1 in dba.Users
                 join c2 in dba.UserRoleGroups on c1.UserId equals c2.UserId
                 where c1.Email == item.Email && c1.Password == item.Password
                 select new
                 {
                     userId = c1.UserId,
                     roleId = c2.RoleId,
                     name = c1.Name,
                     ValidateEmail = c1.ValidateEmail
                     // etc...  
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
                    UserType = (int)UserRole(obj.roleId)
                };

            }
            catch (Exception)
            {
                throw;
            }
        }

        List<string> GetUserRoleGroup(string userId)
        {
            try
            {
                return dba.UserRoleGroups.Where(p => p.UserId == userId).Select(p => p.RoleId).ToList();
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
                return dba.Users.ToList().Select(AutoMapper.Mapper.Map<UserBo>).ToList();
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
                var item = dba.Users.FirstOrDefault(p => p.UserId == userid);
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

        public void  Register(UserBo item)
        {
            try
            {
                if (dba.Users.Count(p => p.Email == item.Email) != 0)
                {
                    throw new PrimaryKeyVialationException("user is already registed");
                }
                string userId = Guid.NewGuid().ToString();
                dba.Users.Add(new Domain.User()
                {
                    Email = item.Email,
                    Password = item.Password,
                    UserId = userId,
                    Active = false,
                    ValidateEmail = false,
                    Name = item.Name
                });
                dba.UserRoleGroups.Add(new UserRoleGroup
                {
                    UserId = userId,
                    RoleId = item.UserType.ToString()

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
                var obj = dba.Users.FirstOrDefault(p => p.UserId == item.UserId);
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

                var obj2 = dba.Users.FirstOrDefault(p => p.Email == email);
                if (obj2==null)
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
        public void ValidateEmailSendEmail(string email, string token)
        {
            throw new NotImplementedException();
        }
        public void ForgetPasswordSendEmail(string email, string token)
        {
            throw new NotImplementedException();
        }

        #endregion


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

        private EUserType UserRole(string role)
        {
            if (role.Equals("Admin"))
            {
                return EUserType.Admin;
            }else if (role.Equals("Citizen"))
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

      
        #endregion
    }
}
