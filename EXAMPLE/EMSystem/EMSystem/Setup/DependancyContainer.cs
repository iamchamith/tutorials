using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using EMSystem.Service;
using System.Web.Mvc;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using AutoMapper;
using EMSystem.Service.Helper;

namespace EMSystem.Setup
{
    public class DependancyContainer
    {
        public static void Inject()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.RegisterRepositories();
            container.Register<IEmployeeService, EmployeeService>();
            var config = MapperContext.Configure();
            container.RegisterSingleton<MapperConfiguration>(config);
            container.Register<IMapper>(() => config.CreateMapper(container.GetInstance));
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

        }
    }
}