using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreDecorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.BalanceHistory.ServiceBus;
using Service.DwhServiceBusBridge.DwhDatabase;

namespace Service.DwhServiceBusBridge.Job
{
    public class SpotTradesWriter
    {
        private ILogger<SpotTradesWriter> _logger;
        private ISubscriber<IReadOnlyList<WalletTradeMessage>> _subscriber;
        private IDwhDbContextFactory _dwhDbContextFactory;

        public SpotTradesWriter(ILogger<SpotTradesWriter> logger, 
            ISubscriber<IReadOnlyList<WalletTradeMessage>> subscriber, 
            IDwhDbContextFactory dwhDbContextFactory)
        {
            _logger = logger;
            _subscriber = subscriber;
            _dwhDbContextFactory = dwhDbContextFactory;
            subscriber.Subscribe(HandleSpotTrade);
        }

        private async ValueTask HandleSpotTrade(IReadOnlyList<WalletTradeMessage> messages)
        {
            await using var ctx = _dwhDbContextFactory.Create();

            var data = messages.Select(WalletTradeMassageEntity.Create).ToList();

            await ctx.WalletTradeMassageTable.UpsertRange(data).RunAsync();
            
            _logger.LogInformation("HandleSpotTrade handled {count}: ", data.Count);
        }
    }
}