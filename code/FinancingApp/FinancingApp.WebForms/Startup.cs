using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinancingApp.WebForms.Startup))]
namespace FinancingApp.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
