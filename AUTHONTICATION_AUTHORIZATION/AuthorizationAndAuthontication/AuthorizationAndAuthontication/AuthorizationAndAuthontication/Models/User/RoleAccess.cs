using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Bo.Enums;

namespace AuthorizationAndAuthontication.Models.User
{
    public class RoleAccess
    {
        public EUserType UserType { get; set; }
        public string Tag { get; set; }
    }
}