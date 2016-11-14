using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Bo.Enums;

namespace AuthorizationAndAuthontication.Models.User
{
    public class UserSession
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; }
    }


}