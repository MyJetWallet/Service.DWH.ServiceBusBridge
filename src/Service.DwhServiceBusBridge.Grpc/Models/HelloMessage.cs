using System.Runtime.Serialization;
using Service.DwhServiceBusBridge.Domain.Models;

namespace Service.DwhServiceBusBridge.Grpc.Models
{
    [DataContract]
    public class HelloMessage : IHelloMessage
    {
        [DataMember(Order = 1)]
        public string Message { get; set; }
    }
}