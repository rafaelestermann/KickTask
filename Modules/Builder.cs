using Autofac;
using KickTask.KickTask;
using KickTask.KickTask.Interfaces;
using KickTask.Models;

namespace KickTask.Modules
{
    public class Builder
    {
        public static IContainer Container { get; set; }

        public void Build()
        {
            Autofac.ContainerBuilder builder = new Autofac.ContainerBuilder();
            builder.RegisterType<DatabaseHandler>().As<IDatabaseHandler>();
            builder.RegisterType<MainModel>().SingleInstance();
            builder.RegisterType<SignUpModel>();
            builder.RegisterType<SignInModel>();
            Container = builder.Build();
        }
    }
}