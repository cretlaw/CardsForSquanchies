using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CardsForSquanchies.Startup))]
namespace CardsForSquanchies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
