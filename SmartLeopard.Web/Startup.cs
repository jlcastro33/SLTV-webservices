using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartLeopard.Web.Startup))]
namespace SmartLeopard.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            AutoMapperConfig.Configure();
        }
    }
}
