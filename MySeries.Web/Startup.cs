using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySeries.Web.Startup))]
namespace MySeries.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
