using System;
using Service.Registration.Domain.Models;

namespace Service.DwhServiceBusBridge.DwhDatabase
{
    public class ClientRegisterFailAlreadyExistsEntity : ClientRegisterFailAlreadyExistsMessage
    {
        public DateTime Timestamp { get; set; }

        public static ClientRegisterFailAlreadyExistsEntity Create(ClientRegisterFailAlreadyExistsMessage message)
        {
            return new ClientRegisterFailAlreadyExistsEntity()
            {
                Timestamp = DateTime.UtcNow,
                IpAddress = message.IpAddress,
                TraderId = message.TraderId,
                UserAgent = message.UserAgent
            };
        }
    }
}