using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AGM.Startup))]
namespace AGM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
