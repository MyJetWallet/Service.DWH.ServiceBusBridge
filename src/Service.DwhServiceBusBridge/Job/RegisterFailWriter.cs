using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreDecorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.DwhServiceBusBridge.DwhDatabase;
using Service.Registration.Domain.Models;

namespace Service.DwhServiceBusBridge.Job
{
    public class RegisterFailWriter
    {
        private ILogger<RegisterFailWriter> _logger;
        private ISubscriber<IReadOnlyList<ClientRegisterFailAlreadyExistsMessage>> _subscriber;
        private IDwhDbContextFactory _dwhDbContextFactory;

        public RegisterFailWriter(ILogger<RegisterFailWriter> logger, 
            ISubscriber<IReadOnlyList<ClientRegisterFailAlreadyExistsMessage>> subscriber, 
            IDwhDbContextFactory dwhDbContextFactory)
        {
            _logger = logger;
            _subscriber = subscriber;
            _dwhDbContextFactory = dwhDbContextFactory;
            subscriber.Subscribe(HandleClientRegisterFailAlreadyExists);
        }

        private async ValueTask HandleClientRegisterFailAlreadyExists(IReadOnlyList<ClientRegisterFailAlreadyExistsMessage> messages)
        {
            try
            {
                await using var ctx = _dwhDbContextFactory.Create();

                var data = messages.Select(ClientRegisterFailAlreadyExistsEntity.Create).ToList();

                await ctx.RegistratinFailTable.UpsertRange(data)
                    .On(e=> new {e.Timestamp})
                    .RunAsync();
                

                _logger.LogInformation("{topic} handled {count} ",ClientRegisterFailAlreadyExistsMessage.TopicName ,data.Count);
            }catch (Exception e)
            {
                _logger.LogError(e, "Exception: {topic} ",ClientRegisterFailAlreadyExistsMessage.TopicName);
                throw;
            }

        }
    }
}