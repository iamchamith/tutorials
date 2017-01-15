using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ANIMATIONS.Startup))]
namespace ANIMATIONS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
