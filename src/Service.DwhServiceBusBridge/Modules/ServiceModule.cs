using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using DotNetCoreDecorators;
using ME.Contracts.OutgoingMessages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyJetWallet.Domain.Prices;
using MyJetWallet.Sdk.Authorization.ServiceBus;
using MyJetWallet.Sdk.ServiceBus;
using MyServiceBus.Abstractions;
using Service.Authorization.Domain.Models.ServiceBus;
using Service.BalanceHistory.ServiceBus;
using Service.Bitgo.DepositDetector.Domain.Models;
using Service.BitGo.SignTransaction.Domain.Models;
using Service.Bitgo.Webhooks.Client;
using Service.Bitgo.Webhooks.Domain.Models;
using Service.Bitgo.WithdrawalProcessor.Domain.Models;
using Service.ChangeBalanceGateway.Grpc.Models;
using Service.Circle.Webhooks.Domain.Models;
using Service.ClientProfile.Domain.Models;
using Service.DwhServiceBusBridge.DwhDatabase;
using Service.DwhServiceBusBridge.Grpc;
using Service.DwhServiceBusBridge.Job;
using Service.FeeShareEngine.Domain.Models.Models;
using Service.InternalTransfer.Domain.Models;
using Service.IntrestManager.Domain.Models;
using Service.Liquidity.Converter.Domain.Models;
using Service.Liquidity.Portfolio.Domain.Models;
using Service.Liquidity.PortfolioHedger.Domain.Models;
using Service.MatchingEngine.EventBridge.ServiceBus;
using Service.PersonalData.Domain.Models.ServiceBus;
using Service.Registration.Domain.Models;
using Service.VerificationCodes.Grpc;
using Service.VerificationCodes.Grpc.Models;
using SimpleTrading.ServiceBus.Models;

namespace Service.DwhServiceBusBridge.Modules
{
    public class ServiceModule: Module
    {

        private void RegisterMessageWriter<TMessage>(ContainerBuilder builder,
            string topicName) where TMessage : class
        {
            builder.RegisterType<MessageWriter<TMessage>>()
                .WithParameter("topicName", topicName)
                .SingleInstance().AutoActivate();
        }

        protected override void Load(ContainerBuilder builder)
        {
            var queryName = "DwhServiceBusBridge";
            
            var serviceBusClient = builder.RegisterMyServiceBusTcpClient(() => Program.Settings.MyServiceBusHostPort, Program.LogFactory);

            builder.RegisterMyServiceBusSubscriberBatch<BidAsk>(serviceBusClient, "jetwallet-external-prices", "DwhServiceBusBridge", TopicQueueType.DeleteOnDisconnect, 1000);

            builder.RegisterType<ExternalPricesWriter>().AsSelf().SingleInstance().AutoActivate();

            builder.RegisterType<DwhDbContextFactory>().As<IDwhDbContextFactory>().SingleInstance();

            builder.RegisterType<SpotBidAskWriter>().AsSelf().SingleInstance().AutoActivate();
            
            builder.RegisterMyServiceBusSubscriberBatch<BidAskServiceBusModel>(serviceBusClient,
                "spot-bidask", queryName, TopicQueueType.DeleteOnDisconnect, 1000);

            /*
            builder.RegisterMyServiceBusSubscriberBatch<SignalBitGoTransfer>(serviceBusClient,
                SignalBitGoTransfer.ServiceBusTopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder, ctx => ctx.SignalBitGoTransfersTable,e=>e.TransferId, SignalBitGoTransfer.ServiceBusTopicName);

            builder.RegisterMyServiceBusSubscriberBatch<SignalBitGoPendingApproval>(serviceBusClient,
                SignalBitGoPendingApproval.ServiceBusTopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder,ctx => ctx.SignalBitGoPendingApprovalTable,e=>e.PendingApprovalId,SignalBitGoPendingApproval.ServiceBusTopicName);

            
            builder.RegisterMyServiceBusSubscriberBatch<SignalCircleTransfer>(serviceBusClient,
                SignalCircleTransfer.ServiceBusTopicName, queryName, TopicQueueType.PermanentWithSingleConnection);

            builder.RegisterType<SignalCircleTransferWriter>().SingleInstance().AutoActivate();
            

            builder.RegisterMyServiceBusSubscriberBatch<SignalBitGoSessionStateUpdate>(serviceBusClient,
                SignalBitGoSessionStateUpdate.ServiceBusTopicName, queryName,
                TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder,ctx => ctx.SignalBitGoSessionStateUpdateTable,e=>e.UpdatedDate,SignalBitGoSessionStateUpdate.ServiceBusTopicName);

            builder.RegisterMyServiceBusSubscriberBatch<FeeShareEntity>(serviceBusClient,
                FeeShareEntity.TopicName,queryName,TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder, ctx => ctx.FeeShareTable,e=>e.FeeTransferOperationId,FeeShareEntity.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<FeePaymentEntity>(serviceBusClient,
                FeePaymentEntity.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder,ctx=> ctx.FeePaymentTable, e=>e.PaymentOperationId,FeePaymentEntity.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<ClientAuthenticationMessage>(serviceBusClient,
                ClientAuthenticationMessage.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);

            builder.RegisterType<ClientAuthenticationMessageWriter>().SingleInstance().AutoActivate();
            
            //RegisterMessageWriter(builder, ctx=> ctx.ClientAuthenticationTable,e=>e.TraderId,ClientAuthenticationMessage.TopicName );

            builder.RegisterMyServiceBusSubscriberBatch<ClientProfileUpdateMessage>(serviceBusClient,
                ClientProfileUpdateMessage.TopicName,queryName, TopicQueueType.PermanentWithSingleConnection);
            
            builder.RegisterType<JetWalletClientProfileUpdateWriter>().SingleInstance().AutoActivate();

            builder.RegisterMyServiceBusSubscriberBatch<Deposit>(serviceBusClient,
                Deposit.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder, ctx=> ctx.DepositTable,e=>e.Id,Deposit.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<Withdrawal>(serviceBusClient,
                Withdrawal.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder, ctx=>ctx.WithdrawalTable,e=>e.Id,Withdrawal.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<WithdrawalVerifiedMessage>(serviceBusClient,
                WithdrawalVerifiedMessage.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder, ctx=> ctx.WithdrawalVerifiedTable,e=>e.WithdrawalProcessId, WithdrawalVerifiedMessage.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<PersonalDataUpdateMessage>(serviceBusClient,
                PersonalDataUpdateMessage.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            builder.RegisterType<PersonalDataUpdateWriter>().SingleInstance().AutoActivate();
*/
            builder.RegisterMyServiceBusSubscriberBatch<Transfer>(serviceBusClient,
                Transfer.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<Transfer>(builder, Transfer.TopicName);
/*
            builder.RegisterMyServiceBusSubscriberBatch<TransferVerificationMessage>(serviceBusClient,
                TransferVerificationMessage.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder, ctx=>ctx.TransferVerificationTable,e=>e.TransferId,TransferVerificationMessage.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<SwapMessage>(serviceBusClient,
                SwapMessage.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder, ctx=>ctx.SwapMessageTable,e=>e.Id, SwapMessage.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<ChangeBalanceHistory>(serviceBusClient,
                ChangeBalanceHistory.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder, ctx=>ctx.ChangeBalanceHistoryTable, e=>e.Id,ChangeBalanceHistory.TopicName );

            builder.RegisterMyServiceBusSubscriberBatch<FeeShareSettlement>(serviceBusClient,
                FeeShareSettlement.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder, ctx=>ctx.FeeShareSettlementTable,e=>e.Id, FeeShareSettlement.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<ManualSettlement>(serviceBusClient,
                ManualSettlement.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder, ctx=>ctx.ManualSettlementTable,e=>e.Id, ManualSettlement.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<AssetPortfolioTrade>(serviceBusClient,
                AssetPortfolioTrade.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder, ctx=>ctx.AssetPortfolioTradeTable, e=>e.Id,AssetPortfolioTrade.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<ClientRegisterFailAlreadyExistsMessage>(serviceBusClient,
                ClientRegisterFailAlreadyExistsMessage.TopicName, queryName,
                TopicQueueType.PermanentWithSingleConnection);

            builder.RegisterType<RegisterFailWriter>().SingleInstance().AutoActivate();

            builder.RegisterMyServiceBusSubscriberBatch<ClientRegisterMessage>(serviceBusClient,
                ClientRegisterMessage.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder, ctx=> ctx.ClientRegisterTable,e=>e.TraderId,ClientRegisterMessage.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<PaidInterestRateMessage>(serviceBusClient,
                PaidInterestRateMessage.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder, ctx=>ctx.PaidInterestRateTable,e=>e.TransactionId, PaidInterestRateMessage.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<WalletTradeMessage>(serviceBusClient,
                WalletTradeMessage.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            builder.RegisterType<SpotTradesWriter>().SingleInstance().AutoActivate();

            builder.RegisterMyServiceBusSubscriberBatch<TradeMessage>(serviceBusClient,
                TradeMessage.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder, ctx=>ctx.TradeMessageTable, e=>e.Id,TradeMessage.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<ManualChangeBalanceMessage>(serviceBusClient,
                "jet-wallet-manual-balance-change-operation", queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter(builder, ctx=> ctx.ManualChangeBalanceOperationTable,e=>e.TransactionId,ManualChangeBalanceMessage.TopicName );



            builder
                .RegisterInstance(new MeEventServiceBusSubscriber(serviceBusClient,  queryName, TopicQueueType.PermanentWithSingleConnection))
                .As<ISubscriber<IReadOnlyList<OutgoingEvent>>>()
                .SingleInstance();

            builder.RegisterType<MeEventWriter>().SingleInstance().AutoActivate();

            builder.RegisterMyServiceBusSubscriberBatch<SessionAuditEvent>(serviceBusClient,
                SessionAuditEvent.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            builder.RegisterType<TokenManagerAuditSessionWriter>().SingleInstance().AutoActivate();
*/
        }
    }
}