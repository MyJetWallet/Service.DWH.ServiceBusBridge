using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreDecorators;
using Microsoft.Extensions.Logging;
using Service.DwhServiceBusBridge.DwhDatabase;
using Service.PersonalData.Domain.Models.ServiceBus;

namespace Service.DwhServiceBusBridge.Job
{
    public class PersonalDataUpdateWriter
    {
        private ILogger<PersonalDataUpdateWriter> _logger;
        private ISubscriber<IReadOnlyList<PersonalDataUpdateMessage>> _subscriber;
        private IDwhDbContextFactory _dwhDbContextFactory;

        public PersonalDataUpdateWriter(ILogger<PersonalDataUpdateWriter> logger, 
            ISubscriber<IReadOnlyList<PersonalDataUpdateMessage>> subscriber, 
            IDwhDbContextFactory dwhDbContextFactory)
        {
            _logger = logger;
            _subscriber = subscriber;
            _dwhDbContextFactory = dwhDbContextFactory;
            subscriber.Subscribe(HandlePersonalDataUpdateSession);
        }

        private async ValueTask HandlePersonalDataUpdateSession(IReadOnlyList<PersonalDataUpdateMessage> messages)
        {
            try
            {
                await using var ctx = _dwhDbContextFactory.Create();

                var data = messages.Select(PersonalDataUpdateEntity.Create).ToList();
                
                await ctx.PersonalDataUpdateTable.AddRangeAsync(data);

                await ctx.SaveChangesAsync();

                _logger.LogInformation("{topic} handled {count} ",PersonalDataUpdateMessage.TopicName ,data.Count);
            } catch (Exception e)
            {
                _logger.LogError(e, " Exception {topic} ",PersonalDataUpdateMessage.TopicName);
                throw;
            }

        }
    }
}