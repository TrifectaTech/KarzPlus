using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KarzPlus.Startup))]
namespace KarzPlus
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
