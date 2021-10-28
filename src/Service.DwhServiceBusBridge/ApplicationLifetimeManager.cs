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
        private readonly SpotBidAskWriter _spotBidAskWriter;

        public ApplicationLifetimeManager(
            IHostApplicationLifetime appLifetime, 
            ILogger<ApplicationLifetimeManager> logger,
            ServiceBusLifeTime serviceBus,
            ExternalPricesWriter externalPricesWriter,
            SpotBidAskWriter spotBidAskWriter)
            : base(appLifetime)
        {
            _logger = logger;
            _serviceBus = serviceBus;
            _externalPricesWriter = externalPricesWriter;
            _spotBidAskWriter = spotBidAskWriter;
        }

        protected override void OnStarted()
        {
            _logger.LogInformation("OnStarted has been called.");
            _serviceBus.Start();
            _externalPricesWriter.Start();
            _spotBidAskWriter.Start();
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
