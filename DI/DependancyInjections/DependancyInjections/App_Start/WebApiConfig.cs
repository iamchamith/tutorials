using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Microsoft.Practices.Unity;
using DependancyInjections.Controllers;
using DependancyInjections.App_Start;
using System.Net.Http.Headers;
using System.Web.Http.Tracing;

namespace DependancyInjections
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));


            //tracing
            config.EnableSystemDiagnosticsTracing();
            System.Web.Http.Tracing.SystemDiagnosticsTraceWriter traceWriter =
                config.EnableSystemDiagnosticsTracing();
            traceWriter.IsVerbose = true;
             
            var container = new UnityContainer();
            container.RegisterType<IDal, SqlDal>(new HierarchicalLifetimeManager());
            container.RegisterType<IDal, OracleDal>(new HierarchicalLifetimeManager());
            container.RegisterType<ICustomer, Customer>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }

     
}
