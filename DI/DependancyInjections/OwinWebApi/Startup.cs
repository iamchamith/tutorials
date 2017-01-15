using Owin;
using OwinWebApi.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace OwinWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder) { 
            HttpConfiguration httpConfiguration = new HttpConfiguration();
           
            appBuilder.Use(httpConfiguration);
        }
    }
}