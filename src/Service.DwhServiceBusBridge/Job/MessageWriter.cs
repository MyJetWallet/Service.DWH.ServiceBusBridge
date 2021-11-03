using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DotNetCoreDecorators;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.DwhServiceBusBridge.DwhDatabase;

namespace Service.DwhServiceBusBridge.Job
{
    public class MessageWriter<TMessage> where TMessage : class
    {
        private ILogger<MessageWriter<TMessage>> _logger;
        private IDwhDbContextFactory _dwhDbContextFactory;
        private readonly string _topicName;

        public MessageWriter(ILogger<MessageWriter<TMessage>> logger, 
            ISubscriber<IReadOnlyList<TMessage>> subscriber, 
            IDwhDbContextFactory dwhDbContextFactory,
            string topicName)
        {
            _logger = logger;
            _dwhDbContextFactory = dwhDbContextFactory;
            _topicName = topicName;
            
            subscriber.Subscribe(HandlerMessage);
        }

        private async ValueTask HandlerMessage(IReadOnlyList<TMessage> messages)
        {
            try
            {
                //DwhContext.LoggerFactory = Program.LogFactory;
                await using var ctx = _dwhDbContextFactory.Create();

                await ctx.BulkInsertAsync(messages.ToList());

                _logger.LogInformation("{topic} handled {count} ", _topicName, messages.Count);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Exception: {topic} ",_topicName);
                throw;
            }

        }
    }
}