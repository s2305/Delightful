using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppDelightful.ViewModel.Startup))]
namespace AppDelightful.ViewModel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
