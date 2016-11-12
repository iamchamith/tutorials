using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
using App.Bo;
using App.DbService.Services.Comman;
using App.DbService.Services.User;
using App.Domain;
using AuthorizationAndAuthontication.App_Start;
using AuthorizationAndAuthontication.Models.User;
using AuthorizationAndAuthontication.Util;

namespace AuthorizationAndAuthontication
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            new AutoMapperConfig();
            Application["emailConfig"] = new EmailConfigService().SelectFirstOrDefault();
            Application["userRoles"] = new UserService().GetRoleTags();
        }
        protected void Application_PostAuthorizeRequest()
        {
            System.Web.HttpContext.Current.SetSessionStateBehavior(System.Web.SessionState.SessionStateBehavior.Required);
        }


    }
}
