using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheDirectory.Startup))]
namespace TheDirectory
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
