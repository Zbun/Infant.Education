using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Infant.Education.Startup))]
namespace Infant.Education
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
