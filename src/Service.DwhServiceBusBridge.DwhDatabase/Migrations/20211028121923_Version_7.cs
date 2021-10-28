using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.DwhServiceBusBridge.DwhDatabase.Migrations
{
    public partial class Version_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JetWalletClientProfileUpdate",
                schema: "sbus",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
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
                    table.PrimaryKey("PK_JetWalletClientProfileUpdate", x => new { x.ClientId, x.Timestamp });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JetWalletClientProfileUpdate",
                schema: "sbus");
        }
    }
}
