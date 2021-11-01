using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreDecorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Authorization.Domain.Models.ServiceBus;
using Service.ClientProfile.Domain.Models;
using Service.DwhServiceBusBridge.DwhDatabase;

namespace Service.DwhServiceBusBridge.Job
{
    public class ClientAuthenticationMessageWriter
    {
        private ILogger<ClientAuthenticationMessageWriter> _logger;
        private ISubscriber<IReadOnlyList<ClientAuthenticationMessage>> _subscriber;
        private IDwhDbContextFactory _dwhDbContextFactory;
        
        
        public ClientAuthenticationMessageWriter(ISubscriber<IReadOnlyList<ClientAuthenticationMessage>> subscriber,
            IDwhDbContextFactory dwhDbContextFactory, 
            ILogger<ClientAuthenticationMessageWriter> logger)
        {

            _logger = logger;
            _subscriber = subscriber;
            _dwhDbContextFactory = dwhDbContextFactory;
            subscriber.Subscribe(HadledClientAuthentification);
        }
        
        private async ValueTask HadledClientAuthentification(IReadOnlyList<ClientAuthenticationMessage> messages)
        {
            try
            {
                await using var ctx = _dwhDbContextFactory.Create();

                var date = messages.Select(ClientAuthenticationMessageEntity.Create).ToList();

                await ctx.ClientAuthenticationTable.UpsertRange(date)
                    .On(e => new { e.TraderId, e.Timestapm })
                    .RunAsync();

                _logger.LogInformation("{topic} handled {count} profile update", ClientAuthenticationMessage.TopicName,
                    messages.Count);

            }
            catch (Exception e)
            {
                _logger.LogError(e, " Exception {topic} ",ClientAuthenticationMessage.TopicName);
                throw;
            }
        }
    }
}