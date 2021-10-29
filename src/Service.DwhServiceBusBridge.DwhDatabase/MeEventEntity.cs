using System;
using Google.Protobuf.WellKnownTypes;
using ME.Contracts.OutgoingMessages;
using Newtonsoft.Json;

namespace Service.DwhServiceBusBridge.DwhDatabase
{
    public class MeEventEntity 
    {
        public string MessageType { get; set; }
        
        public long SequenceNumber { get; set; }
        
        public string MessageId { get; set; }
        
        public string RequestId { get; set; }
        
        public string Version { get; set; }
        
        public DateTime Timestamp { get; set; }
        
        public string EventType { get; set; }
        
        public static MeEventEntity Create (OutgoingEvent ev)
        {
            return new MeEventEntity()
            {
                MessageType = JsonConvert.SerializeObject(ev.Header.MessageType),
                SequenceNumber = ev.Header.SequenceNumber,
                MessageId = ev.Header.MessageId,
                RequestId = ev.Header.RequestId,
                Version = ev.Header.Version,
                Timestamp = ev.Header.Timestamp.ToDateTime(),
                EventType = ev.Header.EventType
            };

        }
    }
}