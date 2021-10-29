﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Service.DwhServiceBusBridge.DwhDatabase;

namespace Service.DwhServiceBusBridge.DwhDatabase.Migrations
{
    [DbContext(typeof(DwhContext))]
    [Migration("20211029114154_Version_1")]
    partial class Version_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("sbus")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyJetWallet.Domain.Prices.BidAsk", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LiquidityProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Ask")
                        .HasColumnType("float");

                    b.Property<double>("Bid")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id", "LiquidityProvider");

                    b.ToTable("JetwalletExternalPrices");
                });

            modelBuilder.Entity("Service.Authorization.Domain.Models.ServiceBus.ClientAuthenticationMessage", b =>
                {
                    b.Property<string>("TraderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAgent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TraderId");

                    b.ToTable("JetWalletClientAuthentification");
                });

            modelBuilder.Entity("Service.BitGo.SignTransaction.Domain.Models.SignalBitGoSessionStateUpdate", b =>
                {
                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UpdatedDate");

                    b.ToTable("BitgoSessionUpdateSignal");
                });

            modelBuilder.Entity("Service.Bitgo.DepositDetector.Domain.Models.Deposit", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("AssetSymbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrokerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardLast4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("FeeAmount")
                        .HasColumnType("float");

                    b.Property<string>("FeeAssetSymbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Integration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastError")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatchingEngineId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Network")
                        .HasColumnType("int");

                    b.Property<int>("RetriesCount")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TransactionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Txid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WalletId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JetWalletCryptoDepositOperation");
                });

            modelBuilder.Entity("Service.Bitgo.Webhooks.Domain.Models.SignalBitGoPendingApproval", b =>
                {
                    b.Property<string>("PendingApprovalId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WalletId")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("PendingApprovalId");

                    b.ToTable("BitgoPendingApprovalSignal");
                });

            modelBuilder.Entity("Service.Bitgo.Webhooks.Domain.Models.SignalBitGoTransfer", b =>
                {
                    b.Property<string>("TransferId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Coin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransferId");

                    b.ToTable("BitgoTransferSignal");
                });

            modelBuilder.Entity("Service.Bitgo.WithdrawalProcessor.Domain.Models.Withdrawal", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<double>("ActualFee")
                        .HasColumnType("float");

                    b.Property<string>("ActualFeeAssetSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("AssetSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrokerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Cancelling")
                        .HasColumnType("bit");

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientLang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationClientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationWalletId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("FeeAmount")
                        .HasColumnType("float");

                    b.Property<string>("FeeAssetSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeeRefundTransactionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Integration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsInternal")
                        .HasColumnType("bit");

                    b.Property<string>("LastError")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatchingEngineId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeErrorCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("NotificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefundTransactionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RetriesCount")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("ToAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Txid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkflowState")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("JetWalletCryptoWithdrawalOperation");
                });

            modelBuilder.Entity("Service.Bitgo.WithdrawalProcessor.Domain.Models.WithdrawalVerifiedMessage", b =>
                {
                    b.Property<string>("WithdrawalProcessId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClientIp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WithdrawalProcessId");

                    b.ToTable("JetWalletCryptoWithdrawalVerification");
                });

            modelBuilder.Entity("Service.ChangeBalanceGateway.Grpc.Models.ManualChangeBalanceMessage", b =>
                {
                    b.Property<string>("TransactionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("AssetSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrokerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("WalletId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionId");

                    b.ToTable("JetWalletManualBalanceChangeOperation");
                });

            modelBuilder.Entity("Service.DwhServiceBusBridge.DwhDatabase.ClientProfileUpdateMessageEntity", b =>
                {
                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("BlockresJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("KYCPassed")
                        .HasColumnType("bit");

                    b.Property<string>("OldProfileJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Status2FA")
                        .HasColumnType("int");

                    b.Property<string>("Status2FEText")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ClientId", "Timestamp", "Id");

                    b.ToTable("JetWalletClientProfileUpdate");
                });

            modelBuilder.Entity("Service.DwhServiceBusBridge.DwhDatabase.ClientRegisterFailAlreadyExistsEntity", b =>
                {
                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TraderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAgent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Timestamp");

                    b.ToTable("JetwalletRegistrationFailedAlreadyExists");
                });

            modelBuilder.Entity("Service.DwhServiceBusBridge.DwhDatabase.MeEventEntity", b =>
                {
                    b.Property<string>("MessageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EventType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SequenceNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.ToTable("MeEvent");
                });

            modelBuilder.Entity("Service.DwhServiceBusBridge.DwhDatabase.PersonalDataUpdateEntity", b =>
                {
                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("TraderId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Timestamp");

                    b.ToTable("JetWalletPersonalDataUpdate");
                });

            modelBuilder.Entity("Service.DwhServiceBusBridge.DwhDatabase.SignalCircleTransferEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Json")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CircleTransferSignal");
                });

            modelBuilder.Entity("Service.DwhServiceBusBridge.DwhDatabase.TestEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("test_table");
                });

            modelBuilder.Entity("Service.DwhServiceBusBridge.DwhDatabase.TokenManagerAuditSessionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Application")
                        .HasColumnType("int");

                    b.Property<string>("BrandId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeviceUid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailVerified")
                        .HasColumnType("bit");

                    b.Property<string>("IP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Passed2FA")
                        .HasColumnType("bit");

                    b.Property<int>("PlatformType")
                        .HasColumnType("int");

                    b.Property<string>("PublicKeyBase64")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RootSessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SessionJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TraderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAgent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TokensManagerAuditSession");
                });

            modelBuilder.Entity("Service.DwhServiceBusBridge.DwhDatabase.WalletTradeMassageEntity", b =>
                {
                    b.Property<string>("TraderUId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("BrokerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TradeJson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TraderUId", "DateTime");

                    b.ToTable("SpotTrades");
                });

            modelBuilder.Entity("Service.FeeShareEngine.Domain.Models.Models.FeePaymentEntity", b =>
                {
                    b.Property<string>("PaymentOperationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CalculationTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("ErrorMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PeriodFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PeriodTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReferrerClientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("PaymentOperationId");

                    b.ToTable("JetWalletFeeSharesPayment");
                });

            modelBuilder.Entity("Service.FeeShareEngine.Domain.Models.Models.FeeShareEntity", b =>
                {
                    b.Property<string>("FeeTransferOperationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BrokerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConverterWalletId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErrorMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FeeAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FeeAsset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FeeShareAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("FeeShareAmountInUsd")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FeeShareWalletId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReferrerClientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("FeeTransferOperationId");

                    b.ToTable("JetWalletFeeShareTransfer");
                });

            modelBuilder.Entity("Service.InternalTransfer.Domain.Models.Transfer", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("AssetSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrokerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Cancelling")
                        .HasColumnType("bit");

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientLang")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationClientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DestinationWalletId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastError")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatchingEngineId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeErrorCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("NotificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefundTransactionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RetriesCount")
                        .HasColumnType("int");

                    b.Property<string>("SenderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TransactionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkflowState")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("JetWalletTransferPhoneOperation");
                });

            modelBuilder.Entity("Service.InternalTransfer.Domain.Models.TransferVerificationMessage", b =>
                {
                    b.Property<string>("TransferId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClientIp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransferId");

                    b.ToTable("JetWalletTransferPhoneVerification");
                });

            modelBuilder.Entity("Service.IntrestManager.Domain.Models.PaidInterestRateMessage", b =>
                {
                    b.Property<string>("TransactionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BrokerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionId");

                    b.ToTable("PaidInterestRate");
                });

            modelBuilder.Entity("Service.Liquidity.Converter.Domain.Models.SwapMessage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountId2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssetId1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssetId2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrokerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DifferenceAsset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DifferenceVolumeAbs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MessageId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Volume1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Volume2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletId1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletId2")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JetwalletLiquidityConvertorSwap");
                });

            modelBuilder.Entity("Service.Liquidity.Portfolio.Domain.Models.AssetPortfolioTrade", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("AssociateBrokerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssociateSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BaseAsset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("BaseAssetPriceInUsd")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BaseVolume")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BaseVolumeInUsd")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ErrorMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeeAsset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FeeVolume")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("QuoteAsset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("QuoteAssetPriceInUsd")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("QuoteVolume")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("QuoteVolumeInUsd")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Side")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalReleasePnl")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TradeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JetwalletLiquidityPortfolioTrades");
                });

            modelBuilder.Entity("Service.Liquidity.Portfolio.Domain.Models.ChangeBalanceHistory", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Asset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("BalanceBeforeUpdate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BrokerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("VolumeDifference")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WalletName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JetwalletLiquidityPortfolioChangebalancehistory");
                });

            modelBuilder.Entity("Service.Liquidity.Portfolio.Domain.Models.FeeShareSettlement", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Asset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrokerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferrerClientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ReleasedPnl")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("SettlementDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("VolumeFrom")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VolumeTo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WalletFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletTo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JetwalletLiquidityPortfolioFeesharesettlement");
                });

            modelBuilder.Entity("Service.Liquidity.Portfolio.Domain.Models.ManualSettlement", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Asset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrokerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ReleasedPnl")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("SettlementDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("VolumeFrom")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("VolumeTo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WalletFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WalletTo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JetwalletLiquidityPortfolioManualsettlement");
                });

            modelBuilder.Entity("Service.Liquidity.PortfolioHedger.Domain.Models.TradeMessage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AssociateBrokerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssociateClientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssociateSymbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssociateWalletId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BaseAsset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeeAsset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("FeeVolume")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Market")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OppositeVolume")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("QuoteAsset")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Side")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Volume")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TradeHedger");
                });

            modelBuilder.Entity("Service.Registration.Domain.Models.ClientRegisterMessage", b =>
                {
                    b.Property<string>("TraderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAgent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TraderId");

                    b.ToTable("JetwalletRegistrationSuccess");
                });

            modelBuilder.Entity("SimpleTrading.ServiceBus.Models.BidAskServiceBusModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Ask")
                        .HasColumnType("float");

                    b.Property<double>("Bid")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SpotBidAsk");
                });
#pragma warning restore 612, 618
        }
    }
}
