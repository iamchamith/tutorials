using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using App.Bo;
using AuthorizationAndAuthontication.Models.User;
using AuthorizationAndAuthontication.Util;
using AutoMapper;

namespace AuthorizationAndAuthontication.Api
{
    [AllowAnonymous]
    //api/Guest/
    public class GuestController : BaseController
    {
        [HttpPost]
        public ActionResult RegisterProcess(UserViewModel user)
        {
            try
            {
             
                userService.Register(Mapper.Map<UserBo>(user),user.UserTypeInfo);
                ValidateEmailTokenUpdate(user.Email);
                return Actions.Success();
            }
            catch (Exception ex)
            {
                return Actions.Error(ex);
            }
        }
        private void ValidateEmailTokenUpdate(string email)
        {
            try
            {
                var token = userService.ValidateEmailTokenUpdate(email);
                Task.Run(() =>
                {
                    userService.ValidateEmailSendEmail(email, token,ApplicationState.EmailDetail);
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public ActionResult LoginProcess(UserViewModel user)
        {
            try
            {
             
                var usr = userService.LoginUser(Mapper.Map<UserBo>(user));
                UserSessionState.UserDetails = Mapper.Map<UserSession>(usr);
                return Actions.Success();
            }
            catch (Exception ex)
            {
                return Actions.Error(ex);
            }
        }
        [HttpGet]
        public ActionResult ValidateEmailAddressProcess(string email, string token)
        {
            try
            {
                userService.VerifyEmailTokenValidate(email, token);
                return Actions.Success();
            }
            catch (Exception ex)
            {
                return Actions.Error(ex);
            }
        }
        [HttpPost]
        public ActionResult ForgertPasswordRequest(string email)
        {
            try
            {
                var token = userService.ForgetPasswordTokenRequest(email);
                Task.Run(() =>
                {
                    userService.ValidateEmailSendEmail(email, token, ApplicationState.EmailDetail);
                });
                return Actions.Success();
            }
            catch (Exception ex)
            {
                return Actions.Error(ex);
            }
        }
        [HttpPost]
        public ActionResult ForgetPasswordValidateProcess(string email, string token)
        {
            try
            {
                userService.ForgetPasswordTokenValidate(email, token);
                return Actions.Success();
            }
            catch (Exception ex)
            {
                return Actions.Error(ex);
            }
        }

        [HttpPost]
        public ActionResult ResendValidateEmailToken(string email)
        {
            try
            {
                ValidateEmailTokenUpdate(email);
                return Actions.Success();
            }
            catch (Exception ex)
            {
                return Actions.Error(ex);
            }

        }
        [HttpPost]
        public ActionResult ResendForgetPasswordToken(string email)
        {
            return ForgertPasswordRequest(email);
        }
        //api/Guest/UserRoles
        [HttpGet]
        public ActionResult UserRoles()
        {
            try
            {
                return Actions.Success(userService.GetSystemRoles());

            }
            catch (Exception ex)
            {
                return Actions.Error(ex);
            }
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            try
            {
                UserSessionState.LogOut();
                return Actions.Success();
            }
            catch (Exception ex)
            {
                return Actions.Error(ex);
            }
            
        }

    }
}
