using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCoreDecorators;
using Microsoft.Extensions.Logging;
using Service.Bitgo.Webhooks.Domain.Models;

namespace Service.DwhServiceBusBridge.Job
{
    public class SignalBitGoTransferWriter
    {
        private readonly ILogger<SignalBitGoTransferWriter> _logger;

        public SignalBitGoTransferWriter(ILogger<SignalBitGoTransferWriter> logger,
            ISubscriber<IReadOnlyList<SignalBitGoTransfer>> subscriber)
        {
            _logger = logger;
            subscriber.Subscribe(HandleMessage);
        }

        private async ValueTask HandleMessage(IReadOnlyList<SignalBitGoTransfer> messages)
        {
            
        }
    }
}