using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreDecorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyJetWallet.Domain.Prices;
using MyJetWallet.Sdk.Service.Tools;
using Service.DwhServiceBusBridge.DwhDatabase;

namespace Service.DwhServiceBusBridge.Job
{
    public class ExternalPricesWriter: IDisposable
    {
        private readonly ILogger<ExternalPricesWriter> _logger;
        private readonly ISubscriber<IReadOnlyList<BidAsk>> _subscriber;
        private readonly IDwhDbContextFactory _dwhDbContextFactory;
        private MyTaskTimer _timer;

        private Dictionary<string, BidAsk> _data = new Dictionary<string, BidAsk>();
        
        public ExternalPricesWriter(ILogger<ExternalPricesWriter> logger,
            ISubscriber<IReadOnlyList<BidAsk>> subscriber,
            IDwhDbContextFactory dwhDbContextFactory)
        {
            _logger = logger;
            _subscriber = subscriber;
            _dwhDbContextFactory = dwhDbContextFactory;

            _timer = new MyTaskTimer(nameof(ExternalPricesWriter), TimeSpan.FromSeconds(5), logger, DoTime);
            subscriber.Subscribe(HandlePrices);
        }

        

        private async ValueTask HandlePrices(IReadOnlyList<BidAsk> prices)
        {
            var actualPrices = prices
                .GroupBy(e => new {e.LiquidityProvider, e.Id})
                .Select(e => e.OrderByDescending(e => e.DateTime).First())
                .ToList();

            lock (_data)
            {
                foreach (var price in actualPrices)
                {
                    _data[$"{price.LiquidityProvider}|||{price.Id}"] = price;
                }
            }

            //_logger.LogInformation("ExternalPricesWriter handled {count} prices", prices.Count);
        }

        public void Start()
        {
            _timer.Start();
        }

        private async Task DoTime()
        {
            var list = new List<BidAsk>();
            lock (_data)
            {
                list = _data.Values.ToList();
            }

            var time = await Sleep();
            
            await using var ctx = _dwhDbContextFactory.Create();

            await ctx.BidAskTable.UpsertRange(list)
                .On(e => new { e.Id, e.LiquidityProvider})
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