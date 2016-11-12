using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using App.DbService;
using App.DbService.Services.User;

namespace AuthorizationAndAuthontication.Api
{
    public class BaseController : ApiController
    {
        protected UserService userService;
        public BaseController()
        {
            userService = new UserService();
        }
    }
}
