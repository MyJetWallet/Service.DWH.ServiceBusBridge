using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.DwhServiceBusBridge.DwhDatabase.Migrations
{
    public partial class Version_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JetWalletClientAuthentification",
                schema: "sbus",
                table: "JetWalletClientAuthentification");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "sbus",
                table: "JetWalletClientAuthentification");

            migrationBuilder.AlterColumn<string>(
                name: "TraderId",
                schema: "sbus",
                table: "JetWalletClientAuthentification",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_JetWalletClientAuthentification",
                schema: "sbus",
                table: "JetWalletClientAuthentification",
                column: "TraderId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BitgoSessionUpdateSignal",
                schema: "sbus");

            migrationBuilder.DropTable(
                name: "BitgoTransferSignal",
                schema: "sbus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JetWalletClientAuthentification",
                schema: "sbus",
                table: "JetWalletClientAuthentification");

            migrationBuilder.AlterColumn<string>(
                name: "TraderId",
                schema: "sbus",
                table: "JetWalletClientAuthentification",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "sbus",
                table: "JetWalletClientAuthentification",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JetWalletClientAuthentification",
                schema: "sbus",
                table: "JetWalletClientAuthentification",
                column: "Id");
        }
    }
}
