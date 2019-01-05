using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(NoKnowService.Startup))]

namespace NoKnowService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}