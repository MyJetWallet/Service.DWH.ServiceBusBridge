using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using MyJetWallet.Domain.Prices;
using MyJetWallet.Sdk.ServiceBus;
using MyServiceBus.Abstractions;
using Service.Bitgo.Webhooks.Client;
using Service.Bitgo.Webhooks.Domain.Models;
using Service.DwhServiceBusBridge.DwhDatabase;
using Service.DwhServiceBusBridge.Job;

namespace Service.DwhServiceBusBridge.Modules
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var queryName = "DwhServiceBusBridge";
            
            var serviceBusClient = builder.RegisterMyServiceBusTcpClient(() => Program.Settings.MyServiceBusHostPort, Program.LogFactory);

            builder.RegisterMyServiceBusSubscriberBatch<BidAsk>(serviceBusClient, "jetwallet-external-prices", "DwhServiceBusBridge", TopicQueueType.DeleteOnDisconnect, 1000);


            builder.RegisterType<ExternalPricesWriter>().AsSelf().SingleInstance().AutoActivate();


            builder.RegisterType<DwhDbContextFactory>().As<IDwhDbContextFactory>().SingleInstance();
            
            builder.RegisterType<SignalBitGoTransferWriter>().AutoActivate().SingleInstance();
            builder.RegisterType<SignalBitGoPendingApprovalWriter>().AutoActivate().SingleInstance();

            builder.RegisterMyServiceBusSubscriberBatch<SignalBitGoTransfer>(serviceBusClient,
                SignalBitGoTransfer.ServiceBusTopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            
            builder.RegisterMyServiceBusSubscriberBatch<SignalBitGoPendingApproval>(serviceBusClient,
                SignalBitGoPendingApproval.ServiceBusTopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            

        }
    }
}