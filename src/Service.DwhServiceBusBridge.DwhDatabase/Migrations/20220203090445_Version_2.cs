using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.DwhServiceBusBridge.DwhDatabase.Migrations
{
    public partial class Version_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CardLast4",
                schema: "sbus",
                table: "JetWalletCryptoDepositOperation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CardLast4",
                schema: "sbus",
                table: "JetWalletCryptoDepositOperation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
