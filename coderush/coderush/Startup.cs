using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(coderush.Startup))]
namespace coderush
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
