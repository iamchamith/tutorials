using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AuthorizationAndAuthontication.Models.User;
using AuthorizationAndAuthontication.Util;

namespace AuthorizationAndAuthontication.Api
{
    public class SystemUserController : BaseController
    {
        //citizen up
        //api/SystemUser/ProfileInfo
        [HttpGet]
        [Access (RoleTags= "site/user/Profile")]
        public ActionResult ProfileInfo()
        {
            try
            {
                return Actions.Success(userService.ReadUser(UserSessionState.UserId));
            }
            catch (Exception ex)
            {
                return Actions.Error(ex);
            }
        }
        //citizen up
        //api/SystemUser/ChangePassowrd
        [HttpGet]
        [Access(RoleTags = "site/user/changePassword")]
        public ActionResult ChangePassowrd()
        {
            return Actions.Success("you can change the password");
        }
        //citizen up
        //api/SystemUser/UpdateSettings
        [HttpGet]
        [Access(RoleTags = "site/user/changeSettings")]
        public ActionResult UpdateSettings()
        {
            return Actions.Success("you can update settings");
        }
        [HttpGet]
        [Access(RoleTags = "site/user/ListUser")]
        public ActionResult ListUsers()
        {
            try
            {
                return Actions.Success(userService.ReadUser());
            }
            catch (Exception ex)
            {
                return Actions.Error(ex);
            }
        }
    }
}