using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearnEnglish.Startup))]
namespace LearnEnglish
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
