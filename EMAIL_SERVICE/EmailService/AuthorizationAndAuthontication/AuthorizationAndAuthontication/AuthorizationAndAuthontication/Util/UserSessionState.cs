﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Bo.Enums;
using AuthorizationAndAuthontication.Models.User;

namespace AuthorizationAndAuthontication.Util
{
    public class UserSessionState
    {
        public static UserSession UserDetails
        {
            get
            {
                var context = System.Web.HttpContext.Current;
                if (context.Session["UserDetailsFromLogin"] != null)
                {
                    return (UserSession)context.Session["UserDetailsFromLogin"];
                }
                return new UserSession();
            }
            set
            {
                var context = System.Web.HttpContext.Current;
                context.Session["UserDetailsFromLogin"] = value;
            }
        }

        public static string Email
        {
            get
            {
                var context = System.Web.HttpContext.Current;
                var user = (UserSession)context.Session["UserDetailsFromLogin"];
                return user.Email;

            }
        }

        public static EUserType UserType
        {
            get
            {
                var context = System.Web.HttpContext.Current;
                var user = (UserSession)context.Session["UserDetailsFromLogin"];
                return (EUserType)user.UserType;
            }
        }
    }
}