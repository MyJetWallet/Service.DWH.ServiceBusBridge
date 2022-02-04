using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using DotNetCoreDecorators;
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
using Service.Liquidity.TradingPortfolio.Domain.Models;
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

            
            builder.RegisterMyServiceBusSubscriberBatch<SignalBitGoTransfer>(serviceBusClient,
                SignalBitGoTransfer.ServiceBusTopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<SignalBitGoTransfer>(builder, SignalBitGoTransfer.ServiceBusTopicName);
            
            
            builder.RegisterMyServiceBusSubscriberBatch<SignalBitGoPendingApproval>(serviceBusClient,
                SignalBitGoPendingApproval.ServiceBusTopicName, queryName, TopicQueueType.PermanentWithSingleConnection);

            RegisterMessageWriter<SignalBitGoPendingApproval>(builder, SignalBitGoPendingApproval.ServiceBusTopicName);


            builder.RegisterMyServiceBusSubscriberBatch<SignalCircleTransfer>(serviceBusClient,
                SignalCircleTransfer.ServiceBusTopicName, queryName, TopicQueueType.PermanentWithSingleConnection);

            builder.RegisterType<SignalCircleTransferWriter>().SingleInstance().AutoActivate();
            
            
            builder.RegisterMyServiceBusSubscriberBatch<SignalBitGoSessionStateUpdate>(serviceBusClient,
                SignalBitGoSessionStateUpdate.ServiceBusTopicName, queryName,
                TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<SignalBitGoSessionStateUpdate>(builder, SignalBitGoSessionStateUpdate.ServiceBusTopicName);
            
            builder.RegisterMyServiceBusSubscriberBatch<FeeShareEntity>(serviceBusClient,
                FeeShareEntity.TopicName,queryName,TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<FeeShareEntity>(builder, FeeShareEntity.TopicName);
            
            builder.RegisterMyServiceBusSubscriberBatch<FeePaymentEntity>(serviceBusClient,
                FeePaymentEntity.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<FeePaymentEntity>(builder, FeePaymentEntity.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<ClientProfileUpdateMessage>(serviceBusClient,
                ClientProfileUpdateMessage.TopicName,queryName, TopicQueueType.PermanentWithSingleConnection);
            
            builder.RegisterType<JetWalletClientProfileUpdateWriter>().SingleInstance().AutoActivate();

            builder.RegisterMyServiceBusSubscriberBatch<Deposit>(serviceBusClient,
                Deposit.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<Deposit>(builder, Deposit.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<Withdrawal>(serviceBusClient,
                Withdrawal.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<Withdrawal>(builder, Withdrawal.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<WithdrawalVerifiedMessage>(serviceBusClient,
                WithdrawalVerifiedMessage.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<WithdrawalVerifiedMessage>(builder, WithdrawalVerifiedMessage.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<PersonalDataUpdateMessage>(serviceBusClient,
                PersonalDataUpdateMessage.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            builder.RegisterType<PersonalDataUpdateWriter>().SingleInstance().AutoActivate();

            builder.RegisterMyServiceBusSubscriberBatch<Transfer>(serviceBusClient,
                Transfer.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<Transfer>(builder, Transfer.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<TransferVerificationMessage>(serviceBusClient,
                TransferVerificationMessage.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<TransferVerificationMessage>(builder, TransferVerificationMessage.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<SwapMessage>(serviceBusClient,
                SwapMessage.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<SwapMessage>(builder, SwapMessage.TopicName);

            RegisterMessageWriter<PortfolioTrade>(builder, PortfolioTrade.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<PortfolioTrade>(serviceBusClient,
                PortfolioTrade.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<PortfolioChangeBalance>(builder, PortfolioChangeBalance.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<PortfolioChangeBalance>(serviceBusClient,
                PortfolioChangeBalance.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<PortfolioSettlement>(builder, PortfolioSettlement.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<PortfolioSettlement>(serviceBusClient,
                PortfolioSettlement.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<PortfolioFeeShare>(builder, PortfolioFeeShare.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<PortfolioFeeShare>(serviceBusClient,
                PortfolioFeeShare.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);

            builder.RegisterMyServiceBusSubscriberBatch<ManualSettlement>(serviceBusClient,
                ManualSettlement.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<ManualSettlement>(builder, ManualSettlement.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<ClientRegisterFailAlreadyExistsMessage>(serviceBusClient,
                ClientRegisterFailAlreadyExistsMessage.TopicName, queryName,
                TopicQueueType.PermanentWithSingleConnection);

            builder.RegisterType<RegisterFailWriter>().SingleInstance().AutoActivate();

            builder.RegisterMyServiceBusSubscriberBatch<ClientRegisterMessage>(serviceBusClient,
                ClientRegisterMessage.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<ClientRegisterMessage>(builder, ClientRegisterMessage.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<PaidInterestRateMessage>(serviceBusClient,
                PaidInterestRateMessage.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<PaidInterestRateMessage>(builder, PaidInterestRateMessage.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<WalletTradeMessage>(serviceBusClient,
                WalletTradeMessage.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            builder.RegisterType<SpotTradesWriter>().SingleInstance().AutoActivate();

            builder.RegisterMyServiceBusSubscriberBatch<TradeMessage>(serviceBusClient,
                TradeMessage.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<TradeMessage>(builder, TradeMessage.TopicName);

            builder.RegisterMyServiceBusSubscriberBatch<ManualChangeBalanceMessage>(serviceBusClient,
                "jet-wallet-manual-balance-change-operation", queryName, TopicQueueType.PermanentWithSingleConnection);
            
            RegisterMessageWriter<ManualChangeBalanceMessage>(builder, ManualChangeBalanceMessage.TopicName);
            
            builder.RegisterMyServiceBusSubscriberBatch<SessionAuditEvent>(serviceBusClient,
                SessionAuditEvent.TopicName, queryName, TopicQueueType.PermanentWithSingleConnection);
            
            builder.RegisterType<TokenManagerAuditSessionWriter>().SingleInstance().AutoActivate();

        }
    }
}