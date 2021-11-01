using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DotNetCoreDecorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.DwhServiceBusBridge.DwhDatabase;

namespace Service.DwhServiceBusBridge.Job
{
    public class MessageWriter<TMessage> where TMessage : class
    {
        private ILogger<MessageWriter<TMessage>> _logger;
        private ISubscriber<IReadOnlyList<TMessage>> _subscriber;
        private IDwhDbContextFactory _dwhDbContextFactory;
        private readonly Func<DwhContext, DbSet<TMessage>> _getterDbSet;
        private readonly Expression<Func<TMessage, object>> _match;
        private readonly string _topicName;

        public MessageWriter(ILogger<MessageWriter<TMessage>> logger, 
            ISubscriber<IReadOnlyList<TMessage>> subscriber, 
            IDwhDbContextFactory dwhDbContextFactory,
            Func<DwhContext,DbSet<TMessage>> getterDbSet,
            Expression<Func<TMessage, object>> match,
            string topicName)
        {
            _logger = logger;
            _subscriber = subscriber;
            _dwhDbContextFactory = dwhDbContextFactory;
            _getterDbSet = getterDbSet;
            _match = match;
            _topicName = topicName;
            subscriber.Subscribe(HandlerMessage);
        }

        private async ValueTask HandlerMessage(IReadOnlyList<TMessage> messages)
        {
            try
            {
                await using var ctx = _dwhDbContextFactory.Create();

                await _getterDbSet(ctx).UpsertRange(messages)
                    .On(_match)
                    .RunAsync();

                
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