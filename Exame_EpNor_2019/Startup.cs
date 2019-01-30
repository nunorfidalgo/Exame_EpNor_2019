using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exame_EpNor_2019.Startup))]
namespace Exame_EpNor_2019
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
