using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SiteECommerce.Startup))]
namespace SiteECommerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
