﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreDecorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyJetWallet.Sdk.Authorization.ServiceBus;
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

                await ctx.PersonalDataUpdateTable.UpsertRange(data)
                    .On(e=>new {e.Timestamp})
                    .RunAsync();

                _logger.LogInformation("HandlePersonalDataUpdateSession handled {count} ", data.Count);
            } catch (Exception e)
            {
                _logger.LogError(e, " Exception HandlePersonalDataUpdateSession ");
                throw;
            }

        }
    }
}