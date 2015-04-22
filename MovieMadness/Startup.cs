using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieMadness.Startup))]
namespace MovieMadness
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
