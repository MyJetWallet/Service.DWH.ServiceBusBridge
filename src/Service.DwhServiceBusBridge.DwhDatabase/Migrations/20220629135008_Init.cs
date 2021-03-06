using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.DwhServiceBusBridge.DwhDatabase.Migrations
{
    public partial class Init : Migration
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
                    WalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PendingApprovalId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "BitgoSessionUpdateSignal",
                schema: "sbus",
                columns: table => new
                {
                    State = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "BitgoTransferSignal",
                schema: "sbus",
                columns: table => new
                {
                    Coin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
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
                    Timestapm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetWalletClientAuthentification", x => new { x.TraderId, x.Timestapm });
                });

            migrationBuilder.CreateTable(
                name: "JetWalletClientProfileUpdate",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldProfileJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlockresJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status2FEText = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    KYCPassed = table.Column<bool>(type: "bit", nullable: false),
                    PhoneConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Status2FA = table.Column<int>(type: "int", nullable: false)
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
                    Amount = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    AssetSymbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Integration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Txid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MatchingEngineId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastError = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RetriesCount = table.Column<int>(type: "int", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeeAmount = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    FeeAssetSymbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardLast4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Network = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetIndexPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IncomingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IncomingFeeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IncomingCompanyFeeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepositWorkflowState = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
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
                    Amount = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
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
                    FeeAmount = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    FeeAssetSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualFee = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    ActualFeeAssetSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInternal = table.Column<bool>(type: "bit", nullable: false),
                    DestinationWalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinationClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeErrorCode = table.Column<int>(type: "int", nullable: false),
                    RefundTransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cancelling = table.Column<bool>(type: "bit", nullable: false),
                    FeeRefundTransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blockchain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastTs = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExternalSystemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetIndexPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignatureIssuedAt = table.Column<long>(type: "bigint", nullable: false),
                    FeeAssetIndexPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeeActualAssetIndexPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeeWalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "JetWalletCryptoWithdrawalVerification",
                schema: "sbus",
                columns: table => new
                {
                    WithdrawalProcessId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientIp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
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
                    ReferrerClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    PeriodFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeriodTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CalculationTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PaymentOperationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferrerWalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastTs = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "JetWalletFeeShareTransfer",
                schema: "sbus",
                columns: table => new
                {
                    ReferrerClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeAmount = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    FeeAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeShareAmountInFeeAsset = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    FeeShareAmountInTargetAsset = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OperationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeTransferOperationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ConverterWalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeShareWalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeShareAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeToTargetConversionRate = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    ReferralClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastTs = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "JetwalletLiquidityConvertorSwap",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    DifferenceVolumeAbs = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    FeeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeePercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeeAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuoteType = table.Column<int>(type: "int", nullable: false),
                    ScheduleType = table.Column<int>(type: "int", nullable: false),
                    MarkUp = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DifferenceVolumePercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
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
                    VolumeFrom = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    VolumeTo = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettlementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleasedPnl = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "JetwalletLiquidityTradingportfolioChangebalance",
                schema: "sbus",
                columns: table => new
                {
                    BrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Asset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BalanceBeforeUpdate = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "JetwalletLiquidityTradingportfolioFeeshare",
                schema: "sbus",
                columns: table => new
                {
                    OperationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Asset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolumeFrom = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    VolumeTo = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferrerClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettlementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "JetwalletLiquidityTradingportfolioSettlement",
                schema: "sbus",
                columns: table => new
                {
                    BrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Asset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolumeFrom = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    VolumeTo = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SettlementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleasedPnl = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "JetwalletLiquidityTradingportfolioTrades",
                schema: "sbus",
                columns: table => new
                {
                    TradeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssociateBrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseWalletName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuoteWalletName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssociateSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuoteAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Side = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    BaseVolume = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    QuoteVolume = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    BaseVolumeInUsd = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    QuoteVolumeInUsd = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    BaseAssetPriceInUsd = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    QuoteAssetPriceInUsd = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeVolume = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    FeeVolumeInUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeeAssetPriceInUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "JetWalletManualBalanceChangeOperation",
                schema: "sbus",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    AssetSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Officer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "JetWalletPersonalDataUpdate",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TraderId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetWalletPersonalDataUpdate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JetwalletRegistrationFailedAlreadyExists",
                schema: "sbus",
                columns: table => new
                {
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TraderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlatformType = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    TraderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
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
                    Amount = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
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
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastTs = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "JetWalletTransferPhoneVerification",
                schema: "sbus",
                columns: table => new
                {
                    TransferId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientIp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
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
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    IndexPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
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
                    DeviceUid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneModel = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Market = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Side = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
                    OppositeVolume = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false),
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
                    FeeVolume = table.Column<decimal>(type: "decimal(18,8)", precision: 18, scale: 8, nullable: false)
                },
                constraints: table =>
                {
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
                name: "JetwalletLiquidityPortfolioManualsettlement",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetwalletLiquidityTradingportfolioChangebalance",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetwalletLiquidityTradingportfolioFeeshare",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetwalletLiquidityTradingportfolioSettlement",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetwalletLiquidityTradingportfolioTrades",
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
