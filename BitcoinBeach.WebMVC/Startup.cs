using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BitcoinBeach.WebMVC.Startup))]
namespace BitcoinBeach.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
