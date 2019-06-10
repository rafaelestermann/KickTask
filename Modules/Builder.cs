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
            builder.RegisterType<DatabaseHandler>().As<IDatabaseHandler>().SingleInstance();
            builder.RegisterType<AuthentificationManager>().As<IAuthentificationManager>().SingleInstance();
            builder.RegisterType<KickTaskConnection>().SingleInstance();
            builder.RegisterType<MainModel>().SingleInstance();
            Container = builder.Build();
        }
    }
}