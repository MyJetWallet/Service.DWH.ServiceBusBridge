using System.ServiceModel;
using System.Threading.Tasks;
using Service.DwhServiceBusBridge.Grpc.Models;

namespace Service.DwhServiceBusBridge.Grpc
{
    [ServiceContract]
    public interface IHelloService
    {
        [OperationContract]
        Task<HelloMessage> SayHelloAsync(HelloRequest request);
    }
}