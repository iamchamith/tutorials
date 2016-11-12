using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthorizationAndAuthontication.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public string AccessDenied()
        {
            return "AccessDenied";
        }

        public string Login()
        {
            return "Please login";
        }
    }
}