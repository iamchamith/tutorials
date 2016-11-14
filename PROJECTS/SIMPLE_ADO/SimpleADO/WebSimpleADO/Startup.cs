using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSimpleADO.Startup))]
namespace WebSimpleADO
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
