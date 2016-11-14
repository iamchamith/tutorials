using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace AuthorizationAndAuthontication.Controllers
{
    public class GuestController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Login()
        {
            return PartialView("_Login");
        }

        public PartialViewResult Register()
        {
            return PartialView("_Register");
        }

        public PartialViewResult ForgetPassword()
        {
            return PartialView("_ForgetPassword");
        }

        public ActionResult ForgetPasswordChangePasswordProcess()
        {
            return View();
        }

        public ActionResult ValidateEmailToken()
        {
            return View();
        }
    }
}