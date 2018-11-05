using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCommerce.Startup))]
namespace WebCommerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           /// teste 3
           /// // lalalalal
            ConfigureAuth(app);
        }
    }
}
