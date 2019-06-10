using KickTask.Models;
using KickTask.Modules;
using Autofac;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KickTask.Startup))]
namespace KickTask
{
    public partial class Startup
    {


        public void Configuration(IAppBuilder app)
        {
            var builder = new Builder();
            builder.Build();
        }
    }
}
