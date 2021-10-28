using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Service.DwhServiceBusBridge.DwhDatabase.Migrations
{
    public partial class Version_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BidAsk",
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
                    table.PrimaryKey("PK_BidAsk", x => new { x.Id, x.LiquidityProvider });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidAsk",
                schema: "sbus");
        }
    }
}
