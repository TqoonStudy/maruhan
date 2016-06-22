using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Band.Startup))]
namespace Band
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
