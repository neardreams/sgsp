using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TSRD.Startup))]
namespace TSRD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
