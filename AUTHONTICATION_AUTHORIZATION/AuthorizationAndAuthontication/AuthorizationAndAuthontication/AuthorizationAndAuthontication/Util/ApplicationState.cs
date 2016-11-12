using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Bo;
using AuthorizationAndAuthontication.Models.User;

namespace AuthorizationAndAuthontication.Util
{
    public class ApplicationState
    {
        public static EmailConfigBo EmailDetail
        {
            get
            {
                var context = System.Web.HttpContext.Current;
                //if (context.Application["emailConfig"] != null)
                //{
                //    return (EmailConfigBo)context.Application["emailConfig"];
                //}
                return new EmailConfigBo()
                {
                    Password = "chamith.solid@1234",SendEmail = "chamith.solid@gmail.com",EnableSSL = true,PortNumber = 587,SmtpAddress = "smtp.gmail.com"
                };
            }
        }

        public static List<RoleAccessBo> RoleAccess {
            get
            {
                var context = System.Web.HttpContext.Current;
                if (context.Application["userRoles"] != null)
                {
                    return (List<RoleAccessBo>)context.Application["userRoles"];
                }
                return new List<RoleAccessBo>();

            }
        }
    }
}