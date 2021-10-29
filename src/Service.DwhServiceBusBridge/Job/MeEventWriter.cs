using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreDecorators;
using ME.Contracts.OutgoingMessages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.DwhServiceBusBridge.DwhDatabase;

namespace Service.DwhServiceBusBridge.Job
{
    public class MeEventWriter
    {
        private ILogger<MeEventWriter> _logger;
        private ISubscriber<IReadOnlyList<OutgoingEvent>> _subscriber;
        private IDwhDbContextFactory _dwhDbContextFactory;

        public MeEventWriter(ILogger<MeEventWriter> logger, 
            ISubscriber<IReadOnlyList<OutgoingEvent>> subscriber, 
            IDwhDbContextFactory dwhDbContextFactory)
        {
            _logger = logger;
            _subscriber = subscriber;
            _dwhDbContextFactory = dwhDbContextFactory;
            subscriber.Subscribe(HandleMeEven);
        }

        private async ValueTask HandleMeEven(IReadOnlyList<OutgoingEvent> messages)
        {
            try
            {
                await using var ctx = _dwhDbContextFactory.Create();

                var data = messages.Select(MeEventEntity.Create).ToList();

                await ctx.MeEventTable.UpsertRange(data)
                    .On(e => new { e.MessageId })
                    .RunAsync();

                _logger.LogInformation("HandleMeEven handled {count} ", data.Count);
            }
            catch (Exception e)
            {
                _logger.LogError(e, " Exception HandleMeEven ");
                throw;
            }

        }
    }
}