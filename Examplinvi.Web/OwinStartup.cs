using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Examplinvi.Web.OwinStartup))]

namespace Examplinvi.Web
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
