using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DonAR.UI.Startup))]
namespace DonAR.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
