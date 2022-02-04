using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.DwhServiceBusBridge.DwhDatabase.Migrations
{
    public partial class Version_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ActualFee",
                schema: "sbus",
                table: "JetWalletCryptoWithdrawalOperation",
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
                name: "ActualFee",
                schema: "sbus",
                table: "JetWalletCryptoWithdrawalOperation",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,8)",
                oldPrecision: 18,
                oldScale: 8);
        }
    }
}
