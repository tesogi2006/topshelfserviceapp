using Autofac;
using Utilities;
using WindowServiceApp.Configs;

namespace WindowServiceApp.IoC
{
    public class MyServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (AssemblyStarter).Assembly).AsImplementedInterfaces();

            builder.RegisterType<MyAppInfo>().As<IAppInfo>();
            builder.RegisterType<MyConfig>().As<IMyConfig>();

            // register service
            builder.RegisterType<MyService>().As<IService>();
        }
    }
}
