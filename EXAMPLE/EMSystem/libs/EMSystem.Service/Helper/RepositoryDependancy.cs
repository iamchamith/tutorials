using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using EMSystem.Data;

namespace EMSystem.Service.Helper
{
    public static class RepositoryDependancy
    {
        public static void RegisterRepositories(this Container container)
        {
            container.Register(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
