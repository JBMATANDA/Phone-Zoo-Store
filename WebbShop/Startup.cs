using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebbShop.Startup))]
namespace WebbShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
