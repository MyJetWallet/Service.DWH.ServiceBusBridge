using System;
using Newtonsoft.Json;
using Service.Circle.Webhooks.Domain.Models;

namespace Service.DwhServiceBusBridge.DwhDatabase
{
    public class SignalCircleTransferEntity 
    {
        public long Id { get; set; }
        public string Json { get; set; }
        
        public static SignalCircleTransferEntity Create(SignalCircleTransfer message)
        {
            return new SignalCircleTransferEntity()
            {
                Json = JsonConvert.SerializeObject(message)
            };
        }
        
    }
}