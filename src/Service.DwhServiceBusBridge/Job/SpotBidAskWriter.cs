using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreDecorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyJetWallet.Sdk.Service.Tools;
using Service.DwhServiceBusBridge.DwhDatabase;
using SimpleTrading.ServiceBus.Models;

namespace Service.DwhServiceBusBridge.Job
{
    public class SpotBidAskWriter : IDisposable
    {
        private ILogger<SpotBidAskWriter> _logger;
        private ISubscriber<IReadOnlyList<BidAskServiceBusModel>> _subscriber;
        private IDwhDbContextFactory _dwhDbContextFactory;
        private MyTaskTimer _timer;

        private Dictionary<string, BidAskServiceBusModel> _data = new Dictionary<string, BidAskServiceBusModel>();

        public SpotBidAskWriter(ILogger<SpotBidAskWriter> logger,
            ISubscriber<IReadOnlyList<BidAskServiceBusModel>> subscriber,
            IDwhDbContextFactory dwhDbContextFactory)
        {
            _logger = logger;
            _subscriber = subscriber;
            _dwhDbContextFactory = dwhDbContextFactory;

            _timer = new MyTaskTimer(nameof(SpotBidAskWriter), TimeSpan.FromSeconds(5), logger, DoTime);
            subscriber.Subscribe(HandleSpotBidAskPrices);
        }

        

        private async ValueTask HandleSpotBidAskPrices(IReadOnlyList<BidAskServiceBusModel> prices)
        {
            var actualPrices = prices
                .GroupBy(e => new {e.Id})
                .Select(e => e.OrderByDescending(e => e.DateTime).First())
                .ToList();

            lock (_data)
            {
                foreach (var price in actualPrices)
                {
                    _data[$"{price.Id}"] = price;
                }
            }

            _logger.LogInformation("HandleSpotBidAskPrices handled {count} Spot BidAsk", prices.Count);
        }

        public void Start()
        {
            _timer.Start();
        }

        private async Task DoTime()
        {
            var list = new List<BidAskServiceBusModel>();
            lock (_data)
            {
                list = _data.Values.ToList();
            }

            var time = await Sleep();

            await using var ctx = _dwhDbContextFactory.Create();

            await ctx.SpotBidAskTable.UpsertRange(list)
                .On(e => new { e.Id })
                .RunAsync();
        }

        private async Task<int> Sleep()
        {
            await Task.Delay(5000);

            return 5000;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
        
    }
}