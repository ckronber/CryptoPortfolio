using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CryptoPortfolio.Startup))]
namespace CryptoPortfolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
