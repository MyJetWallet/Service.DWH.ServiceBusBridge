using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreDecorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyJetWallet.Sdk.Authorization.ServiceBus;
using Service.DwhServiceBusBridge.DwhDatabase;

namespace Service.DwhServiceBusBridge.Job
{
    public class TokenManagerAuditSessionWriter
    {
        private ILogger<TokenManagerAuditSessionWriter> _logger;
        private ISubscriber<IReadOnlyList<SessionAuditEvent>> _subscriber;
        private IDwhDbContextFactory _dwhDbContextFactory;

        public TokenManagerAuditSessionWriter(ILogger<TokenManagerAuditSessionWriter> logger, 
            ISubscriber<IReadOnlyList<SessionAuditEvent>> subscriber, 
            IDwhDbContextFactory dwhDbContextFactory)
        {
            _logger = logger;
            _subscriber = subscriber;
            _dwhDbContextFactory = dwhDbContextFactory;
            subscriber.Subscribe(HandleAuditTokenManagerSession);
        }

        private async ValueTask HandleAuditTokenManagerSession(IReadOnlyList<SessionAuditEvent> messages)
        {
            try
            {
                await using var ctx = _dwhDbContextFactory.Create();

                var data = messages.Select(TokenManagerAuditSessionEntity.Create).ToList();

                await ctx.TokenManagerAuditSessionTable.AddRangeAsync(data);

                
                /*
                await ctx.TokenManagerAuditSessionTable.UpsertRange(data)
                    .On(e=>new{e.Id})
                    .RunAsync();*/
                
                await ctx.SaveChangesAsync();

                _logger.LogInformation("HandleAuditTokenManagerSession handled {count} ", data.Count);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception: HandleAuditTokenManagerSession ");
                throw;
            }

        }
    }
}