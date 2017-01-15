using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using ALL.App_Start;

namespace ALL
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //register deferent media type
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
             
            // Enable attribute routing
            config.MapHttpAttributeRoutes();
           
            //convention-based routing
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                // router template is change from the mvc routing.
                // in mvc routing this name goes as url
                routeTemplate: "api/{controller}/{action}/{id}", 
                defaults: new { id = RouteParameter.Optional }
            );

            UnityConfig.Register(config);
        }
    }
}
