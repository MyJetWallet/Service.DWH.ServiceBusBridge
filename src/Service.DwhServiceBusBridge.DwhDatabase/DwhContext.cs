using DotNetCoreDecorators;
using Microsoft.EntityFrameworkCore;
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
        
        public DbSet<ClientAuthenticationMessage> ClientAuthenticationTable { get; set; }

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
            modelBuilder.Entity<ManualChangeBalanceMessage>().HasKey(e => new { e.TransactionId });
            modelBuilder.Entity<ManualChangeBalanceMessage>().Property(e => e.TransactionId).ValueGeneratedNever();

            modelBuilder.Entity<ClientAuthenticationMessage>().ToTable("JetWalletClientAuthentification");
            modelBuilder.Entity<ClientAuthenticationMessage>().HasKey(e => new { e.TraderId });
            modelBuilder.Entity<ClientAuthenticationMessage>().Property(e => e.TraderId).ValueGeneratedNever();

            modelBuilder.Entity<SignalBitGoPendingApproval>().ToTable("BitgoPendingApprovalSignal");
            modelBuilder.Entity<SignalBitGoPendingApproval>().HasKey(e => new { e.PendingApprovalId });
            modelBuilder.Entity<SignalBitGoPendingApproval>().Property(e => e.PendingApprovalId).ValueGeneratedNever();
            modelBuilder.Entity<SignalBitGoPendingApproval>().Property(e => e.WalletId).HasMaxLength(255);

            modelBuilder.Entity<SignalBitGoSessionStateUpdate>().ToTable("BitgoSessionUpdateSignal");
            modelBuilder.Entity<SignalBitGoSessionStateUpdate>().HasKey(e => new { e.UpdatedDate });
            modelBuilder.Entity<SignalBitGoSessionStateUpdate>().Property(e => e.UpdatedDate).ValueGeneratedNever();

            modelBuilder.Entity<SignalBitGoTransfer>().ToTable("BitgoTransferSignal");
            modelBuilder.Entity<SignalBitGoTransfer>().HasKey(e => new { e.TransferId });
            modelBuilder.Entity<SignalBitGoTransfer>().Property(e => e.TransferId).ValueGeneratedNever();


            modelBuilder.Entity<BidAskServiceBusModel>().ToTable("SpotBidAsk");
            modelBuilder.Entity<BidAskServiceBusModel>().HasKey(e => e.Id);
            modelBuilder.Entity<BidAskServiceBusModel>().Property(e => e.Id).ValueGeneratedNever();

            
            modelBuilder.Entity<ClientProfileUpdateMessageEntity>().ToTable("JetWalletClientProfileUpdate");
            modelBuilder.Entity<ClientProfileUpdateMessageEntity>().HasKey(e => new {e.ClientId, e.Timestamp});
            modelBuilder.Entity<ClientProfileUpdateMessageEntity>().Ignore(e => e.Blockers);
            modelBuilder.Entity<ClientProfileUpdateMessageEntity>().Property(e => e.Status2FEText).HasMaxLength(20);
            modelBuilder.Entity<ClientProfileUpdateMessageEntity>().Property(e => e.ClientId).ValueGeneratedNever();
            modelBuilder.Entity<ClientProfileUpdateMessageEntity>().Property(e => e.Timestamp).ValueGeneratedNever();

            modelBuilder.Entity<FeeShareEntity>().ToTable("JetWalletFeeShareTransfer");
            modelBuilder.Entity<FeeShareEntity>().HasKey(e => e.FeeTransferOperationId);
            modelBuilder.Entity<FeeShareEntity>().Property(e => e.FeeTransferOperationId).ValueGeneratedNever();

            modelBuilder.Entity<FeePaymentEntity>().ToTable("JetWalletFeeSharesPayment");
            modelBuilder.Entity<FeePaymentEntity>().HasKey(e => e.PaymentOperationId);
            modelBuilder.Entity<FeePaymentEntity>().Property(e => e.PaymentOperationId).ValueGeneratedNever();

            modelBuilder.Entity<Deposit>().ToTable("JetWalletCryptoDepositOperation");
            modelBuilder.Entity<Deposit>().HasKey(e => e.TransactionId);
            modelBuilder.Entity<Deposit>().Property(e => e.TransactionId).ValueGeneratedNever();

            modelBuilder.Entity<Withdrawal>().ToTable("JetWalletCryptoWithdrawalOperation");
            modelBuilder.Entity<Withdrawal>().HasKey(e => e.TransactionId);
            modelBuilder.Entity<Withdrawal>().Property(e => e.TransactionId).ValueGeneratedNever();

            modelBuilder.Entity<WithdrawalVerifiedMessage>().ToTable("JetWalletCryptoWithdrawalVerification");
            modelBuilder.Entity<WithdrawalVerifiedMessage>().HasKey(e => e.WithdrawalProcessId);
            modelBuilder.Entity<WithdrawalVerifiedMessage>().Property(e => e.WithdrawalProcessId).ValueGeneratedNever();

            modelBuilder.Entity<Transfer>().ToTable("JetWalletTransferPhoneOperation");
            modelBuilder.Entity<Transfer>().HasKey(e => e.TransactionId);
            modelBuilder.Entity<Transfer>().Property(e => e.TransactionId).ValueGeneratedNever();            
            
            
            modelBuilder.Entity<TransferVerificationMessage>().ToTable("JetWalletTransferPhoneVerification");
            modelBuilder.Entity<TransferVerificationMessage>().HasKey(e => e.TransferId);
            modelBuilder.Entity<TransferVerificationMessage>().Property(e => e.TransferId).ValueGeneratedNever();

            modelBuilder.Entity<SwapMessage>().ToTable("JetwalletLiquidityConvertorSwap");
            modelBuilder.Entity<SwapMessage>().HasKey(e=>e.Id);
            modelBuilder.Entity<SwapMessage>().Property(e=>e.Id).ValueGeneratedNever();

            modelBuilder.Entity<ChangeBalanceHistory>().ToTable("JetwalletLiquidityPortfolioChangebalancehistory");
            modelBuilder.Entity<ChangeBalanceHistory>().HasKey(e=>e.Id);
            modelBuilder.Entity<ChangeBalanceHistory>().Property(e=>e.Id).ValueGeneratedNever();
            
            modelBuilder.Entity<FeeShareSettlement>().ToTable("JetwalletLiquidityPortfolioFeesharesettlement");
            modelBuilder.Entity<FeeShareSettlement>().HasKey(e=>e.Id);
            modelBuilder.Entity<FeeShareSettlement>().Property(e=>e.Id).ValueGeneratedNever();
            
            modelBuilder.Entity<ManualSettlement>().ToTable("JetwalletLiquidityPortfolioManualsettlement");
            modelBuilder.Entity<ManualSettlement>().HasKey(e=>e.Id);
            modelBuilder.Entity<ManualSettlement>().Property(e=>e.Id).ValueGeneratedNever();
            
            modelBuilder.Entity<AssetPortfolioTrade>().ToTable("JetwalletLiquidityPortfolioTrades");
            modelBuilder.Entity<AssetPortfolioTrade>().HasKey(e=>e.Id);
            modelBuilder.Entity<AssetPortfolioTrade>().Property(e=>e.Id).ValueGeneratedNever();
            
            modelBuilder.Entity<PaidInterestRateMessage>().ToTable("PaidInterestRate");
            modelBuilder.Entity<PaidInterestRateMessage>().HasKey(e=>e.TransactionId);
            modelBuilder.Entity<PaidInterestRateMessage>().Property(e=>e.TransactionId).ValueGeneratedNever();
            
            modelBuilder.Entity<TradeMessage>().ToTable("TradeHedger");
            modelBuilder.Entity<TradeMessage>().HasKey(e=>e.Id);
            modelBuilder.Entity<TradeMessage>().Property(e=>e.Id).ValueGeneratedNever();

            modelBuilder.Entity<TokenManagerAuditSessionEntity>().ToTable("TokensManagerAuditSession");
            modelBuilder.Entity<TokenManagerAuditSessionEntity>().HasKey(e=>e.Timestamp);
            modelBuilder.Entity<TokenManagerAuditSessionEntity>().Property(e=>e.Timestamp).ValueGeneratedNever();
            modelBuilder.Entity<TokenManagerAuditSessionEntity>().Property(e=>e.Action).HasMaxLength(20);

            modelBuilder.Entity<WalletTradeMassageEntity>().ToTable("SpotTrades");
            modelBuilder.Entity<WalletTradeMassageEntity>().HasKey(e=> new {e.TraderUId, e.DateTime});
            modelBuilder.Entity<WalletTradeMassageEntity>().Property(e=>e.TraderUId).ValueGeneratedNever();
            modelBuilder.Entity<WalletTradeMassageEntity>().Property(e=>e.DateTime).ValueGeneratedNever();
            
        }
    }
}