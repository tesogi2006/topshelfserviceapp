using System.Threading;
using System.Threading.Tasks;
using log4net;
using Utilities;
using WindowServiceApp.Configs;

namespace WindowServiceApp
{
    public class MyService : IService
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IMyConfig _config;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly CancellationToken _cancellationToken;
        private readonly Task _task;

        public MyService(IMyConfig config)
        {
            _config = config;
            _cancellationToken = _cancellationTokenSource.Token;
            _task = new Task(DoWork, _cancellationToken);
        }

        public void StartService()
        {
            _task.Start();
        }

        public void StopService()
        {
            _cancellationTokenSource.Cancel();
            _task.Wait();
            Logger.Debug("Stopping service");
        }

        public void DoWork()
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                var num = 5;
                while (num > 0)
                {
                    Logger.Info($"Connecting in .... {num} seconds" );
                    Thread.Sleep(1500);
                    num--;
                }
                Logger.Info("**** Please wait ****");
                Thread.Sleep(5000);
            }
        }
    }
}
