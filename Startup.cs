using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_WH.Startup))]
namespace MVC_WH
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
