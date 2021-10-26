using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyJetWallet.Sdk.Service;
using MyJetWallet.Sdk.ServiceBus;
using Service.DwhServiceBusBridge.Job;

namespace Service.DwhServiceBusBridge
{
    public class ApplicationLifetimeManager : ApplicationLifetimeManagerBase
    {
        private readonly ILogger<ApplicationLifetimeManager> _logger;
        private readonly ServiceBusLifeTime _serviceBus;
        private readonly ExternalPricesWriter _externalPricesWriter;

        public ApplicationLifetimeManager(
            IHostApplicationLifetime appLifetime, 
            ILogger<ApplicationLifetimeManager> logger,
            ServiceBusLifeTime serviceBus,
            ExternalPricesWriter externalPricesWriter)
            : base(appLifetime)
        {
            _logger = logger;
            _serviceBus = serviceBus;
            _externalPricesWriter = externalPricesWriter;
        }

        protected override void OnStarted()
        {
            _logger.LogInformation("OnStarted has been called.");
            _serviceBus.Start();
            _externalPricesWriter.Start();
        }

        protected override void OnStopping()
        {
            _logger.LogInformation("OnStopping has been called.");
            _serviceBus.Stop();
        }

        protected override void OnStopped()
        {
            _logger.LogInformation("OnStopped has been called.");
        }
    }
}
