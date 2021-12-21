using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service.DwhServiceBusBridge.DwhDatabase.Migrations
{
    public partial class LatTs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastChangeTimestamp",
                schema: "sbus",
                table: "JetWalletClientProfileUpdate",
                newName: "LastTs");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastTs",
                schema: "sbus",
                table: "JetWalletTransferPhoneOperation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastTs",
                schema: "sbus",
                table: "JetWalletFeeShareTransfer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastTs",
                schema: "sbus",
                table: "JetWalletFeeSharesPayment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Network",
                schema: "sbus",
                table: "JetWalletCryptoDepositOperation",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastTs",
                schema: "sbus",
                table: "JetWalletTransferPhoneOperation");

            migrationBuilder.DropColumn(
                name: "LastTs",
                schema: "sbus",
                table: "JetWalletFeeShareTransfer");

            migrationBuilder.DropColumn(
                name: "LastTs",
                schema: "sbus",
                table: "JetWalletFeeSharesPayment");

            migrationBuilder.RenameColumn(
                name: "LastTs",
                schema: "sbus",
                table: "JetWalletClientProfileUpdate",
                newName: "LastChangeTimestamp");

            migrationBuilder.AlterColumn<int>(
                name: "Network",
                schema: "sbus",
                table: "JetWalletCryptoDepositOperation",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
