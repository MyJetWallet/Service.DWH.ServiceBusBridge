using System;
using Service.Authorization.Domain.Models.ServiceBus;

namespace Service.DwhServiceBusBridge.DwhDatabase
{
    public class ClientAuthenticationMessageEntity :ClientAuthenticationMessage
    {
       
        public DateTime Timestapm { get; set; }

        public static ClientAuthenticationMessageEntity Create(ClientAuthenticationMessage message)
        {
            return new ClientAuthenticationMessageEntity()
            {
                Timestapm = DateTime.UtcNow,
                Brand = message.Brand,
                Ip = message.Ip,
                LanguageId = message.LanguageId,
                TraderId = message.TraderId,
                UserAgent = message.UserAgent
            };
        }
    }
}