using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BuildCRUD.Startup))]
namespace BuildCRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
