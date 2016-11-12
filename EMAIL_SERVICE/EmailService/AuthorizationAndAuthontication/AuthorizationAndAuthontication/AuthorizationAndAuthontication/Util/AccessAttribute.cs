using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Bo.Enums;
using AuthorizationAndAuthontication.Models.User;


namespace AuthorizationAndAuthontication.Util
{
    public class AccessAttribute : AuthorizeAttribute
    {
        public string RoleTags { get; set; }
         protected override bool AuthorizeCore(HttpContextBase context)
        {
            var tags= RoleTags.Split(new[] { "$" }, StringSplitOptions.RemoveEmptyEntries);
            var validRequest = false;
            EUserType a =  GetUserType(context);
            return validRequest;
        }

        public static EUserType GetUserType(HttpContextBase context)
        {
               var user = (UserSession)context.Session["UserDetailsFromLogin"];
               return (EUserType)user.UserType;
        }
    }
}