using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.DwhServiceBusBridge.DwhDatabase.Migrations
{
    public partial class Version_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sbus");

            migrationBuilder.CreateTable(
                name: "BitgoPendingApprovalSignal",
                schema: "sbus",
                columns: table => new
                {
                    PendingApprovalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WalletId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitgoPendingApprovalSignal", x => x.PendingApprovalId);
                });

            migrationBuilder.CreateTable(
                name: "BitgoSessionUpdateSignal",
                schema: "sbus",
                columns: table => new
                {
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitgoSessionUpdateSignal", x => x.UpdatedDate);
                });

            migrationBuilder.CreateTable(
                name: "BitgoTransferSignal",
                schema: "sbus",
                columns: table => new
                {
                    TransferId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Coin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitgoTransferSignal", x => x.TransferId);
                });

            migrationBuilder.CreateTable(
                name: "CircleTransferSignal",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Json = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CircleTransferSignal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JetWalletClientAuthentification",
                schema: "sbus",
                columns: table => new
                {
                    TraderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetWalletClientAuthentification", x => x.TraderId);
                });

            migrationBuilder.CreateTable(
                name: "JetWalletClientProfileUpdate",
                schema: "sbus",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldProfileJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlockresJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status2FEText = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Status2FA = table.Column<int>(type: "int", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PhoneConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    KYCPassed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetWalletClientProfileUpdate", x => new { x.ClientId, x.Timestamp, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "JetWalletCryptoDepositOperation",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BrokerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WalletId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    AssetSymbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Integration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Txid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MatchingEngineId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastError = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RetriesCount = table.Column<int>(type: "int", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeeAmount = table.Column<double>(type: "float", nullable: false),
                    FeeAssetSymbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardLast4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Network = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetWalletCryptoDepositOperation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JetWalletCryptoWithdrawalOperation",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    AssetSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Integration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Txid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MatchingEngineId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastError = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RetriesCount = table.Column<int>(type: "int", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientLang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkflowState = table.Column<int>(type: "int", nullable: false),
                    FeeAmount = table.Column<double>(type: "float", nullable: false),
                    FeeAssetSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualFee = table.Column<double>(type: "float", nullable: false),
                    ActualFeeAssetSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInternal = table.Column<bool>(type: "bit", nullable: false),
                    DestinationWalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeErrorCode = table.Column<int>(type: "int", nullable: false),
                    RefundTransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cancelling = table.Column<bool>(type: "bit", nullable: false),
                    FeeRefundTransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetWalletCryptoWithdrawalOperation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JetWalletCryptoWithdrawalVerification",
                schema: "sbus",
                columns: table => new
                {
                    WithdrawalProcessId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientIp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetWalletCryptoWithdrawalVerification", x => x.WithdrawalProcessId);
                });

            migrationBuilder.CreateTable(
                name: "JetwalletExternalPrices",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LiquidityProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bid = table.Column<double>(type: "float", nullable: false),
                    Ask = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetwalletExternalPrices", x => new { x.Id, x.LiquidityProvider });
                });

            migrationBuilder.CreateTable(
                name: "JetWalletFeeSharesPayment",
                schema: "sbus",
                columns: table => new
                {
                    PaymentOperationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReferrerClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PeriodFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CalculationTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetWalletFeeSharesPayment", x => x.PaymentOperationId);
                });

            migrationBuilder.CreateTable(
                name: "JetWalletFeeShareTransfer",
                schema: "sbus",
                columns: table => new
                {
                    FeeTransferOperationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReferrerClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeeAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeShareAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeeShareAmountInUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OperationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ConverterWalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeShareWalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetWalletFeeShareTransfer", x => x.FeeTransferOperationId);
                });

            migrationBuilder.CreateTable(
                name: "JetwalletLiquidityConvertorSwap",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MessageId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletId1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetId1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Volume1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountId2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletId2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetId2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Volume2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifferenceAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifferenceVolumeAbs = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetwalletLiquidityConvertorSwap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JetwalletLiquidityPortfolioChangebalancehistory",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Asset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolumeDifference = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BalanceBeforeUpdate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetwalletLiquidityPortfolioChangebalancehistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JetwalletLiquidityPortfolioFeesharesettlement",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Asset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolumeFrom = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VolumeTo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferrerClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettlementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleasedPnl = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetwalletLiquidityPortfolioFeesharesettlement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JetwalletLiquidityPortfolioManualsettlement",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Asset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolumeFrom = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VolumeTo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettlementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleasedPnl = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetwalletLiquidityPortfolioManualsettlement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JetwalletLiquidityPortfolioTrades",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    TradeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssociateBrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssociateSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuoteAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Side = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BaseVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuoteVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BaseVolumeInUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuoteVolumeInUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BaseAssetPriceInUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuoteAssetPriceInUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalReleasePnl = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeeAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetwalletLiquidityPortfolioTrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JetWalletManualBalanceChangeOperation",
                schema: "sbus",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    AssetSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetWalletManualBalanceChangeOperation", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "JetWalletPersonalDataUpdate",
                schema: "sbus",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TraderId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetWalletPersonalDataUpdate", x => x.Timestamp);
                });

            migrationBuilder.CreateTable(
                name: "JetwalletRegistrationFailedAlreadyExists",
                schema: "sbus",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TraderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetwalletRegistrationFailedAlreadyExists", x => x.Timestamp);
                });

            migrationBuilder.CreateTable(
                name: "JetwalletRegistrationSuccess",
                schema: "sbus",
                columns: table => new
                {
                    TraderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetwalletRegistrationSuccess", x => x.TraderId);
                });

            migrationBuilder.CreateTable(
                name: "JetWalletTransferPhoneOperation",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    BrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    AssetSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationWalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MatchingEngineId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastError = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RetriesCount = table.Column<int>(type: "int", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientLang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkflowState = table.Column<int>(type: "int", nullable: false),
                    RefundTransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cancelling = table.Column<bool>(type: "bit", nullable: false),
                    MeErrorCode = table.Column<int>(type: "int", nullable: false),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetWalletTransferPhoneOperation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JetWalletTransferPhoneVerification",
                schema: "sbus",
                columns: table => new
                {
                    TransferId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientIp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetWalletTransferPhoneVerification", x => x.TransferId);
                });

            migrationBuilder.CreateTable(
                name: "MeEvent",
                schema: "sbus",
                columns: table => new
                {
                    MessageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MessageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SequenceNumber = table.Column<long>(type: "bigint", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeEvent", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "PaidInterestRate",
                schema: "sbus",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaidInterestRate", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "SpotBidAsk",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bid = table.Column<double>(type: "float", nullable: false),
                    Ask = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpotBidAsk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpotTrades",
                schema: "sbus",
                columns: table => new
                {
                    TraderUId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TradeJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpotTrades", x => new { x.TraderUId, x.DateTime });
                });

            migrationBuilder.CreateTable(
                name: "test_table",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_table", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TokensManagerAuditSession",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RootSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TraderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicKeyBase64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passed2FA = table.Column<bool>(type: "bit", nullable: false),
                    EmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlatformType = table.Column<int>(type: "int", nullable: false),
                    Application = table.Column<int>(type: "int", nullable: false),
                    DeviceUid = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokensManagerAuditSession", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TradeHedger",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Market = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Side = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OppositeVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssociateWalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssociateBrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssociateClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssociateSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuoteAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeHedger", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BitgoPendingApprovalSignal",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "BitgoSessionUpdateSignal",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "BitgoTransferSignal",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "CircleTransferSignal",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetWalletClientAuthentification",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetWalletClientProfileUpdate",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetWalletCryptoDepositOperation",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetWalletCryptoWithdrawalOperation",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetWalletCryptoWithdrawalVerification",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetwalletExternalPrices",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetWalletFeeSharesPayment",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetWalletFeeShareTransfer",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetwalletLiquidityConvertorSwap",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetwalletLiquidityPortfolioChangebalancehistory",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetwalletLiquidityPortfolioFeesharesettlement",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetwalletLiquidityPortfolioManualsettlement",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetwalletLiquidityPortfolioTrades",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetWalletManualBalanceChangeOperation",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetWalletPersonalDataUpdate",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetwalletRegistrationFailedAlreadyExists",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetwalletRegistrationSuccess",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetWalletTransferPhoneOperation",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetWalletTransferPhoneVerification",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "MeEvent",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "PaidInterestRate",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "SpotBidAsk",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "SpotTrades",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "test_table",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "TokensManagerAuditSession",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "TradeHedger",
                schema: "sbus");
        }
    }
}
