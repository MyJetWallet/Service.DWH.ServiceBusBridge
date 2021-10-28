using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreDecorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.ClientProfile.Domain.Models;
using Service.DwhServiceBusBridge.DwhDatabase;

namespace Service.DwhServiceBusBridge.Job
{
    public class JetWalletClientProfileUpdateWriter
    {
        
        private ILogger<JetWalletClientProfileUpdateWriter> _logger;
        private ISubscriber<IReadOnlyList<ClientProfileUpdateMessage>> _subscriber;
        private IDwhDbContextFactory _dwhDbContextFactory;
        
        
        public JetWalletClientProfileUpdateWriter(ISubscriber<IReadOnlyList<ClientProfileUpdateMessage>> subscriber,
            IDwhDbContextFactory dwhDbContextFactory, 
            ILogger<JetWalletClientProfileUpdateWriter> logger)
        {

            _logger = logger;
            _subscriber = subscriber;
            _dwhDbContextFactory = dwhDbContextFactory;
            subscriber.Subscribe(HadledProfileUpdate);
        }
        
        private async ValueTask HadledProfileUpdate(IReadOnlyList<ClientProfileUpdateMessage> messages)
        {
            await using var ctx = _dwhDbContextFactory.Create();

            var date = messages.Select(ClientProfileUpdateMessageEntity.Create).ToList();

            await ctx.ClientProfileUpdateTable.UpsertRange(date)
                .On(e=> new{e.ClientId, e.Timestamp})
                .RunAsync();

            _logger.LogInformation("HadledProfileUpdate handled {count} profile update", messages.Count);

        }
        
    }
}