using System;
using Service.PersonalData.Domain.Models.ServiceBus;

namespace Service.DwhServiceBusBridge.DwhDatabase
{
    public class PersonalDataUpdateEntity : PersonalDataUpdateMessage
    {
        public long Id { get; set; }
        public DateTime Timestamp { get; set; }

        public static PersonalDataUpdateEntity Create(PersonalDataUpdateMessage message)
        {
            return new PersonalDataUpdateEntity()
            {
                TraderId = message.TraderId,
                Timestamp = DateTime.UtcNow
            };
        }
    }
    
}