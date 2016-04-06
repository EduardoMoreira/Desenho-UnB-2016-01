using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FarmManager.Startup))]
namespace FarmManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
