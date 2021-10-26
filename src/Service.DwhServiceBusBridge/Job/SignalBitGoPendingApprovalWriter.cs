using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCoreDecorators;
using Microsoft.Extensions.Logging;
using Service.Bitgo.Webhooks.Domain.Models;

namespace Service.DwhServiceBusBridge.Job
{
    public class SignalBitGoPendingApprovalWriter
    {
        private readonly ILogger<SignalBitGoPendingApprovalWriter> _logger;

        public SignalBitGoPendingApprovalWriter(ILogger<SignalBitGoPendingApprovalWriter> logger,
            ISubscriber<IReadOnlyList<SignalBitGoPendingApproval>> subscriber)
        {
            _logger = logger;
            subscriber.Subscribe(HandleMessage);
        }

        private async ValueTask HandleMessage(IReadOnlyList<SignalBitGoPendingApproval> messages)
        {
            
        }
    }
}