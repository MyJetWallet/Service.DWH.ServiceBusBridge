using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.DwhServiceBusBridge.DwhDatabase.Migrations
{
    public partial class Version_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ManualChangeBalanceOperationTable",
                schema: "sbus",
                table: "ManualChangeBalanceOperationTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BidAsk",
                schema: "sbus",
                table: "BidAsk");

            migrationBuilder.RenameTable(
                name: "ManualChangeBalanceOperationTable",
                schema: "sbus",
                newName: "JetWalletManualBalanceChangeOperation",
                newSchema: "sbus");

            migrationBuilder.RenameTable(
                name: "BidAsk",
                schema: "sbus",
                newName: "JetwalletExternalPrices",
                newSchema: "sbus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JetWalletManualBalanceChangeOperation",
                schema: "sbus",
                table: "JetWalletManualBalanceChangeOperation",
                column: "TransactionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JetwalletExternalPrices",
                schema: "sbus",
                table: "JetwalletExternalPrices",
                columns: new[] { "Id", "LiquidityProvider" });

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
                name: "JetWalletClientAuthentification",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraderId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JetWalletClientAuthentification", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BitgoPendingApprovalSignal",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "JetWalletClientAuthentification",
                schema: "sbus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JetWalletManualBalanceChangeOperation",
                schema: "sbus",
                table: "JetWalletManualBalanceChangeOperation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JetwalletExternalPrices",
                schema: "sbus",
                table: "JetwalletExternalPrices");

            migrationBuilder.RenameTable(
                name: "JetWalletManualBalanceChangeOperation",
                schema: "sbus",
                newName: "ManualChangeBalanceOperationTable",
                newSchema: "sbus");

            migrationBuilder.RenameTable(
                name: "JetwalletExternalPrices",
                schema: "sbus",
                newName: "BidAsk",
                newSchema: "sbus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ManualChangeBalanceOperationTable",
                schema: "sbus",
                table: "ManualChangeBalanceOperationTable",
                column: "TransactionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BidAsk",
                schema: "sbus",
                table: "BidAsk",
                columns: new[] { "Id", "LiquidityProvider" });
        }
    }
}
