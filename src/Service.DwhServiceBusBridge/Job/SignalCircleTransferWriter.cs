using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreDecorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Circle.Webhooks.Domain.Models;
using Service.DwhServiceBusBridge.DwhDatabase;

namespace Service.DwhServiceBusBridge.Job
{
    public class SignalCircleTransferWriter
    {
        
        private ILogger<SignalCircleTransferWriter> _logger;
        private ISubscriber<IReadOnlyList<SignalCircleTransfer>> _subscriber;
        private IDwhDbContextFactory _dwhDbContextFactory;

        public SignalCircleTransferWriter(ILogger<SignalCircleTransferWriter> logger, 
            ISubscriber<IReadOnlyList<SignalCircleTransfer>> subscriber, 
            IDwhDbContextFactory dwhDbContextFactory)
        {
            _logger = logger;
            _subscriber = subscriber;
            _dwhDbContextFactory = dwhDbContextFactory;
            subscriber.Subscribe(HandleSignalCircleTransfer);
        }

        private async ValueTask HandleSignalCircleTransfer(IReadOnlyList<SignalCircleTransfer> messages)
        {
            try
            {
                await using var ctx = _dwhDbContextFactory.Create();

                var data = messages.Select(SignalCircleTransferEntity.Create).ToList();

                await ctx.CircleTransferTable.AddRangeAsync(data);

                _logger.LogInformation("{topic} handled {count} ",SignalCircleTransfer.ServiceBusTopicName ,data.Count);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception: {topic} ", SignalCircleTransfer.ServiceBusTopicName);
                throw;
            }

        }
        
    }
}