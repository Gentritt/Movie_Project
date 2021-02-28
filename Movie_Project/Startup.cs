using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Movie_Project.Startup))]
namespace Movie_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
