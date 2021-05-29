using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieRenderApp.Startup))]
namespace MovieRenderApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
