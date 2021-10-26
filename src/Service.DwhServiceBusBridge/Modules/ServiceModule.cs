using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using MyJetWallet.Sdk.ServiceBus;

namespace Service.DwhServiceBusBridge.Modules
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var serviceBusClient = builder.RegisterMyServiceBusTcpClient(() => Program.Settings.MyServiceBusHostPort, Program.LogFactory);
            
            
        }
    }
}