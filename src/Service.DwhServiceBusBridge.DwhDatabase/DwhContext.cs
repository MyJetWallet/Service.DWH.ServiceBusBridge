using DotNetCoreDecorators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using MyJetWallet.Domain.Prices;
using Service.Authorization.Domain.Models.ServiceBus;
using Service.Bitgo.DepositDetector.Domain.Models;
using Service.BitGo.SignTransaction.Domain.Models;
using Service.Bitgo.Webhooks.Domain.Models;
using Service.Bitgo.WithdrawalProcessor.Domain.Models;
using Service.ChangeBalanceGateway.Grpc.Models;
using Service.Circle.Webhooks.Domain.Models;
using Service.ClientProfile.Domain.Models;
using Service.FeeShareEngine.Domain.Models.Models;
using Service.InternalTransfer.Domain.Models;
using Service.IntrestManager.Domain.Models;
using Service.Liquidity.Converter.Domain.Models;
using Service.Liquidity.Portfolio.Domain.Models;
using Service.Liquidity.PortfolioHedger.Domain.Models;
using Service.Registration.Domain.Models;
using SimpleTrading.ServiceBus.Models;

namespace Service.DwhServiceBusBridge.DwhDatabase
{
    public class DwhContext : DbContext
    {
        public const string Schema = "sbus";
        public const string TestTableName = "test_table";

        public static ILoggerFactory LoggerFactory { get; set; }
        
        public DbSet<TestEntity> TestTable { get; set; }
        
        public DbSet<BidAsk> BidAskTable { get; set; }
        
        public DbSet<ManualChangeBalanceMessage> ManualChangeBalanceOperationTable { get; set; }
        
        public DbSet<ClientAuthenticationMessageEntity> ClientAuthenticationTable { get; set; }

        public DbSet<SignalBitGoPendingApproval> SignalBitGoPendingApprovalTable { get; set; }
        
        public DbSet<SignalBitGoSessionStateUpdate> SignalBitGoSessionStateUpdateTable { get; set; }
        
        public DbSet<SignalBitGoTransfer> SignalBitGoTransfersTable { get; set; }
        
        public DbSet<BidAskServiceBusModel> SpotBidAskTable { get; set; }

        public DbSet<ClientProfileUpdateMessageEntity> ClientProfileUpdateTable { get; set; }
        
        public DbSet<FeeShareEntity> FeeShareTable { get; set; }
        
        public DbSet<FeePaymentEntity> FeePaymentTable { get; set; } 
        
        public DbSet<Deposit> DepositTable { get; set; }
        
        public DbSet<Withdrawal> WithdrawalTable { get; set; }
        
        public DbSet<WithdrawalVerifiedMessage> WithdrawalVerifiedTable { get; set; }
        
        public DbSet<Transfer> TransferTable { get; set; }
        
        public DbSet<TransferVerificationMessage> TransferVerificationTable { get; set; }
        
        public DbSet<SwapMessage> SwapMessageTable { get; set; }  
        
        public DbSet<ChangeBalanceHistory> ChangeBalanceHistoryTable { get; set; }
        
        public DbSet<FeeShareSettlement> FeeShareSettlementTable { get; set; }
        
        public DbSet<ManualSettlement> ManualSettlementTable { get; set; }
        
        public DbSet<AssetPortfolioTrade> AssetPortfolioTradeTable { get; set; }
        
        public DbSet<PaidInterestRateMessage> PaidInterestRateTable { get; set; }
        
        public DbSet<TradeMessage> TradeMessageTable { get; set; }
        
        public DbSet<TokenManagerAuditSessionEntity> TokenManagerAuditSessionTable { get; set; }
        
        public DbSet<WalletTradeMassageEntity> WalletTradeMassageTable { get; set; }
        
        public DbSet<PersonalDataUpdateEntity> PersonalDataUpdateTable { get; set; }
        
        public DbSet<ClientRegisterFailAlreadyExistsEntity> RegistratinFailTable { get; set; }
        
        public DbSet<ClientRegisterMessage> ClientRegisterTable { get; set; }
        
        public DbSet<MeEventEntity> MeEventTable { get; set; }
        
       public DbSet<SignalCircleTransferEntity> CircleTransferTable { get; set; }


        public DwhContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (LoggerFactory != null)
            {
                optionsBuilder.UseLoggerFactory(LoggerFactory).EnableSensitiveDataLogging();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.Entity<TestEntity>().ToTable(TestTableName);
            modelBuilder.Entity<TestEntity>().HasKey(e => new { e.Id });
            modelBuilder.Entity<TestEntity>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<TestEntity>().Property(e => e.Message).HasMaxLength(255);

            modelBuilder.Entity<BidAsk>().ToTable("JetwalletExternalPrices");
            modelBuilder.Entity<BidAsk>().HasKey(e => new { e.Id, e.LiquidityProvider });
            modelBuilder.Entity<BidAsk>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<BidAsk>().Property(e => e.DateTime);
            modelBuilder.Entity<BidAsk>().Property(e => e.Bid);
            modelBuilder.Entity<BidAsk>().Property(e => e.Ask);
            modelBuilder.Entity<BidAsk>().Property(e => e.LiquidityProvider).ValueGeneratedNever();

            modelBuilder.Entity<ManualChangeBalanceMessage>().ToTable("JetWalletManualBalanceChangeOperation");
            modelBuilder.Entity<ManualChangeBalanceMessage>().HasNoKey();

            modelBuilder.Entity<ClientAuthenticationMessageEntity>().ToTable("JetWalletClientAuthentification");
            modelBuilder.Entity<ClientAuthenticationMessageEntity>().HasKey(e => new { e.TraderId, e.Timestapm });
            modelBuilder.Entity<ClientAuthenticationMessageEntity>().Property(e => e.TraderId).ValueGeneratedNever();
            modelBuilder.Entity<ClientAuthenticationMessageEntity>().Property(e => e.Timestapm).ValueGeneratedNever();

            modelBuilder.Entity<SignalBitGoPendingApproval>().ToTable("BitgoPendingApprovalSignal");
            modelBuilder.Entity<SignalBitGoPendingApproval>().HasNoKey();

            modelBuilder.Entity<SignalBitGoSessionStateUpdate>().ToTable("BitgoSessionUpdateSignal");
            modelBuilder.Entity<SignalBitGoSessionStateUpdate>().HasNoKey();

            modelBuilder.Entity<SignalBitGoTransfer>().ToTable("BitgoTransferSignal");
            modelBuilder.Entity<SignalBitGoTransfer>().HasNoKey();


            modelBuilder.Entity<BidAskServiceBusModel>().ToTable("SpotBidAsk");
            modelBuilder.Entity<BidAskServiceBusModel>().HasKey(e => e.Id);
            modelBuilder.Entity<BidAskServiceBusModel>().Property(e => e.Id).ValueGeneratedNever();

            
            modelBuilder.Entity<ClientProfileUpdateMessageEntity>().ToTable("JetWalletClientProfileUpdate");
            modelBuilder.Entity<ClientProfileUpdateMessageEntity>().HasKey(e => new {e.ClientId, e.Timestamp, e.Id});
            modelBuilder.Entity<ClientProfileUpdateMessageEntity>().Ignore(e => e.Blockers);
            modelBuilder.Entity<ClientProfileUpdateMessageEntity>().Property(e => e.Status2FEText).HasMaxLength(20);
            modelBuilder.Entity<ClientProfileUpdateMessageEntity>().Property(e => e.ClientId).ValueGeneratedNever();
            modelBuilder.Entity<ClientProfileUpdateMessageEntity>().Property(e => e.Id);
            modelBuilder.Entity<ClientProfileUpdateMessageEntity>().Property(e => e.Timestamp).ValueGeneratedNever();

            modelBuilder.Entity<FeeShareEntity>().ToTable("JetWalletFeeShareTransfer");
            modelBuilder.Entity<FeeShareEntity>().HasNoKey();

            modelBuilder.Entity<FeePaymentEntity>().ToTable("JetWalletFeeSharesPayment");
            modelBuilder.Entity<FeePaymentEntity>().HasNoKey();

            modelBuilder.Entity<Deposit>().ToTable("JetWalletCryptoDepositOperation");
            modelBuilder.Entity<Deposit>().HasNoKey();
            modelBuilder.Entity<Deposit>().Property(e => e.MatchingEngineId).IsRequired(false);
            modelBuilder.Entity<Deposit>().Property(e => e.LastError).IsRequired(false);

            modelBuilder.Entity<Withdrawal>().ToTable("JetWalletCryptoWithdrawalOperation");
            modelBuilder.Entity<Withdrawal>().HasNoKey();

            modelBuilder.Entity<WithdrawalVerifiedMessage>().ToTable("JetWalletCryptoWithdrawalVerification");
            modelBuilder.Entity<WithdrawalVerifiedMessage>().HasNoKey();

            modelBuilder.Entity<Transfer>().ToTable("JetWalletTransferPhoneOperation");
            modelBuilder.Entity<Transfer>().HasNoKey();         
            
            
            modelBuilder.Entity<TransferVerificationMessage>().ToTable("JetWalletTransferPhoneVerification");
            modelBuilder.Entity<TransferVerificationMessage>().HasNoKey();

            modelBuilder.Entity<SwapMessage>().ToTable("JetwalletLiquidityConvertorSwap");
            modelBuilder.Entity<SwapMessage>().HasNoKey();

            modelBuilder.Entity<ChangeBalanceHistory>().ToTable("JetwalletLiquidityPortfolioChangebalancehistory");
            modelBuilder.Entity<ChangeBalanceHistory>().HasNoKey();
            
            modelBuilder.Entity<FeeShareSettlement>().ToTable("JetwalletLiquidityPortfolioFeesharesettlement");
            modelBuilder.Entity<FeeShareSettlement>().HasNoKey();
            
            modelBuilder.Entity<ManualSettlement>().ToTable("JetwalletLiquidityPortfolioManualsettlement");
            modelBuilder.Entity<ManualSettlement>().HasNoKey();
            
            modelBuilder.Entity<AssetPortfolioTrade>().ToTable("JetwalletLiquidityPortfolioTrades");
            modelBuilder.Entity<AssetPortfolioTrade>().HasNoKey();
            
            modelBuilder.Entity<PaidInterestRateMessage>().ToTable("PaidInterestRate");
            modelBuilder.Entity<PaidInterestRateMessage>().HasNoKey();
            
            modelBuilder.Entity<TradeMessage>().ToTable("TradeHedger");
            modelBuilder.Entity<TradeMessage>().HasNoKey();

            modelBuilder.Entity<TokenManagerAuditSessionEntity>().ToTable("TokensManagerAuditSession");
            modelBuilder.Entity<TokenManagerAuditSessionEntity>().HasKey(e=>new {e.Id});
            modelBuilder.Entity<TokenManagerAuditSessionEntity>().Property(e=>e.Action).HasMaxLength(20);

            modelBuilder.Entity<WalletTradeMassageEntity>().ToTable("SpotTrades");
            modelBuilder.Entity<WalletTradeMassageEntity>().HasKey(e=> new {e.TraderUId, e.DateTime});
            modelBuilder.Entity<WalletTradeMassageEntity>().Property(e=>e.TraderUId).ValueGeneratedNever();
            modelBuilder.Entity<WalletTradeMassageEntity>().Property(e=>e.DateTime).ValueGeneratedNever();
            modelBuilder.Entity<WalletTradeMassageEntity>().Ignore(e => e.Trade);

            modelBuilder.Entity<PersonalDataUpdateEntity>().ToTable("JetWalletPersonalDataUpdate");
            modelBuilder.Entity<PersonalDataUpdateEntity>().HasKey(e=>e.Timestamp);
            modelBuilder.Entity<PersonalDataUpdateEntity>().Property(e=>e.Timestamp).ValueGeneratedNever();

            modelBuilder.Entity<ClientRegisterFailAlreadyExistsEntity>().ToTable("JetwalletRegistrationFailedAlreadyExists");
            modelBuilder.Entity<ClientRegisterFailAlreadyExistsEntity>().HasKey(e=>e.Timestamp);
            modelBuilder.Entity<ClientRegisterFailAlreadyExistsEntity>().Property(e=>e.Timestamp).ValueGeneratedNever();

            modelBuilder.Entity<ClientRegisterMessage>().ToTable("JetwalletRegistrationSuccess");
            modelBuilder.Entity<ClientRegisterMessage>().HasNoKey();

            modelBuilder.Entity<MeEventEntity>().ToTable("MeEvent");
            modelBuilder.Entity<MeEventEntity>().HasKey(e=>e.MessageId);
            modelBuilder.Entity<MeEventEntity>().Property(e=>e.MessageId).ValueGeneratedNever();

            
            modelBuilder.Entity<SignalCircleTransferEntity>().ToTable("CircleTransferSignal");
            modelBuilder.Entity<SignalCircleTransferEntity>().HasKey(e=> e.Id);
            
        }
    }
}