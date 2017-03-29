using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WoW.Startup))]
namespace WoW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
        }
    }
}
