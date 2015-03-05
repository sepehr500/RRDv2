using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RRDv2.Startup))]
namespace RRDv2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
