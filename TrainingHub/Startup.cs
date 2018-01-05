using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrainingHub.Startup))]
namespace TrainingHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
