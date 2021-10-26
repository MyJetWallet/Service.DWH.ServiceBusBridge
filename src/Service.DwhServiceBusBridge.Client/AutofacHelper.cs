using Autofac;
using Service.DwhServiceBusBridge.Grpc;

// ReSharper disable UnusedMember.Global

namespace Service.DwhServiceBusBridge.Client
{
    public static class AutofacHelper
    {
        public static void RegisterDwhServiceBusBridgeClient(this ContainerBuilder builder, string grpcServiceUrl)
        {
            var factory = new DwhServiceBusBridgeClientFactory(grpcServiceUrl);

            builder.RegisterInstance(factory.GetHelloService()).As<IHelloService>().SingleInstance();
        }
    }
}
