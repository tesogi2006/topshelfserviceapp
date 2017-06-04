using Autofac;
using log4net;
using log4net.Config;
using Topshelf;
using WindowServiceApp.Configs;
using WindowServiceApp.IoC;

namespace WindowServiceApp
{
    static class MyProgram
    {
        private static ILog _logger;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            XmlConfigurator.Configure();
            _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            _logger.Debug($"WindowsServiceApp is initializing");

            var container = Bootstrapper.Initialize<MyServiceModule>();

            HostFactory.Run(host =>
            {
                host.UseLog4Net();
                host.Service<IService>(config =>
                {
                    config.ConstructUsing(() => container.Resolve<IService>());
                    config.WhenStarted(service => service.StartService());
                    config.WhenStopped(service => service.StopService());
                });

                host.RunAsLocalSystem();
                host.SetServiceName("My Windows Service");
            });
        }
    }
}
