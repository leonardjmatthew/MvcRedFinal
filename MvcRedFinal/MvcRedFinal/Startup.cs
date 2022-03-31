using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcRedFinal.Startup))]
namespace MvcRedFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
