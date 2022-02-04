using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.DwhServiceBusBridge.DwhDatabase.Migrations
{
    public partial class Version_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetPortfolioTradeTable",
                schema: "sbus");

            migrationBuilder.AlterColumn<decimal>(
                name: "QuoteVolumeInUsd",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioTrades",
                type: "decimal(18,8)",
                precision: 18,
                scale: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "QuoteVolume",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioTrades",
                type: "decimal(18,8)",
                precision: 18,
                scale: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "QuoteAssetPriceInUsd",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioTrades",
                type: "decimal(18,8)",
                precision: 18,
                scale: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioTrades",
                type: "decimal(18,8)",
                precision: 18,
                scale: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FeeVolume",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioTrades",
                type: "decimal(18,8)",
                precision: 18,
                scale: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BaseVolumeInUsd",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioTrades",
                type: "decimal(18,8)",
                precision: 18,
                scale: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BaseVolume",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioTrades",
                type: "decimal(18,8)",
                precision: 18,
                scale: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BaseAssetPriceInUsd",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioTrades",
                type: "decimal(18,8)",
                precision: 18,
                scale: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "VolumeTo",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioSettlement",
                type: "decimal(18,8)",
                precision: 18,
                scale: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "VolumeFrom",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioSettlement",
                type: "decimal(18,8)",
                precision: 18,
                scale: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ReleasedPnl",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioSettlement",
                type: "decimal(18,8)",
                precision: 18,
                scale: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "VolumeTo",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioFeeshare",
                type: "decimal(18,8)",
                precision: 18,
                scale: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "VolumeFrom",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioFeeshare",
                type: "decimal(18,8)",
                precision: 18,
                scale: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BalanceBeforeUpdate",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioChangebalance",
                type: "decimal(18,8)",
                precision: 18,
                scale: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioChangebalance",
                type: "decimal(18,8)",
                precision: 18,
                scale: 8,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "QuoteVolumeInUsd",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioTrades",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldPrecision: 18,
                oldScale: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "QuoteVolume",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioTrades",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldPrecision: 18,
                oldScale: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "QuoteAssetPriceInUsd",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioTrades",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldPrecision: 18,
                oldScale: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioTrades",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldPrecision: 18,
                oldScale: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "FeeVolume",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioTrades",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldPrecision: 18,
                oldScale: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "BaseVolumeInUsd",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioTrades",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldPrecision: 18,
                oldScale: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "BaseVolume",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioTrades",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldPrecision: 18,
                oldScale: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "BaseAssetPriceInUsd",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioTrades",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldPrecision: 18,
                oldScale: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "VolumeTo",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioSettlement",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldPrecision: 18,
                oldScale: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "VolumeFrom",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioSettlement",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldPrecision: 18,
                oldScale: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "ReleasedPnl",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioSettlement",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldPrecision: 18,
                oldScale: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "VolumeTo",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioFeeshare",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldPrecision: 18,
                oldScale: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "VolumeFrom",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioFeeshare",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldPrecision: 18,
                oldScale: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "BalanceBeforeUpdate",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioChangebalance",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldPrecision: 18,
                oldScale: 8);

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                schema: "sbus",
                table: "JetwalletLiquidityTradingportfolioChangebalance",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldPrecision: 18,
                oldScale: 8);

            migrationBuilder.CreateTable(
                name: "AssetPortfolioTradeTable",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssociateBrokerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssociateSymbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseAssetPriceInUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BaseVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BaseVolumeInUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeeVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuoteAsset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuoteAssetPriceInUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuoteVolume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuoteVolumeInUsd = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Side = table.Column<int>(type: "int", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalReleasePnl = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TradeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalletName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetPortfolioTradeTable", x => x.Id);
                });
        }
    }
}
