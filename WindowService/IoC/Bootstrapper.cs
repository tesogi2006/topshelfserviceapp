using System.Reflection;
using Autofac;

namespace WindowServiceApp.IoC
{
    /// <summary>
    /// This is the class to handle the registeration of modules needed by the service
    /// </summary>
    public static class Bootstrapper
    {
        public static IContainer Initialize<TModule>(params Assembly[] assemblies) where TModule : Autofac.Module, new()
        {
            var builder = new ContainerBuilder();

            #region Assembly Scans
            // current assembly
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();

            // assembly arguments
            builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces();
            #endregion

            #region Modules

            builder.RegisterModule<TModule>();

            #endregion

            return builder.Build();
        }
    }
}
