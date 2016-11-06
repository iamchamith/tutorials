using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using StudentManegementSystem.App_Start;

[assembly: OwinStartup(typeof(StudentManegementSystem.Startup))]

namespace StudentManegementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            new AutomapperConfig();
        }
    }
}
