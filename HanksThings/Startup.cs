using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HanksThings.Startup))]
namespace HanksThings
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
