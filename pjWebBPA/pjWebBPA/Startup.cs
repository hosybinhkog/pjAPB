using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(pjWebBPA.StartupOwin))]

namespace pjWebBPA
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
