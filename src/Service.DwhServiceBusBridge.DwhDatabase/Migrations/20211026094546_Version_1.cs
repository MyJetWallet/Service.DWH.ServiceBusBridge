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
                name: "TestTableName",
                schema: "sbus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTableName", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestTableName",
                schema: "sbus");
        }
    }
}
