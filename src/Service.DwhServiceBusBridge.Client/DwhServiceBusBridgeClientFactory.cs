using JetBrains.Annotations;
using MyJetWallet.Sdk.Grpc;
using Service.DwhServiceBusBridge.Grpc;

namespace Service.DwhServiceBusBridge.Client
{
    [UsedImplicitly]
    public class DwhServiceBusBridgeClientFactory: MyGrpcClientFactory
    {
        public DwhServiceBusBridgeClientFactory(string grpcServiceUrl) : base(grpcServiceUrl)
        {
        }

        public IHelloService GetHelloService() => CreateGrpcService<IHelloService>();
    }
}
