using ANIMATIONS.Service;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ANIMATIONS.App_Start
{
    public static class IocConfiig
    {
        public static void ConfigIocUnityContainer() {

            IUnityContainer container = new UnityContainer();

            RegisterServices(container);
            DependencyResolver.SetResolver(new UnityDependancyResolver(container));
        }

        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<ILocalWettherServiceProvider, LocalWettherServiceProvider>();
        }
    }

    public class UnityDependancyResolver : IDependencyResolver
    {
        private IUnityContainer _unityContainer;

        public UnityDependancyResolver(IUnityContainer unityContainer) {
            this._unityContainer = unityContainer;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _unityContainer.Resolve(serviceType);
            }
            catch 
            {
                throw;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _unityContainer.ResolveAll(serviceType);
            }
            catch
            {
                throw;
            }
        }
    }
}