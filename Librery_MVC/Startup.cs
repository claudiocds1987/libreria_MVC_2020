using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Librery_MVC.Startup))]
namespace Librery_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
