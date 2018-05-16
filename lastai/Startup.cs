using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lastai.Startup))]
namespace lastai
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
