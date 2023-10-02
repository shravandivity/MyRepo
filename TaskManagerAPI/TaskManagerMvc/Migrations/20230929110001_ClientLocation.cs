using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagerMvc.Migrations
{
    /// <inheritdoc />
    public partial class ClientLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TeamSize",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ClientLocationId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ClientLocations",
                columns: table => new
                {
                    ClientLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientLocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientLocations", x => x.ClientLocationId);
                });

            migrationBuilder.InsertData(
                table: "ClientLocations",
                columns: new[] { "ClientLocationId", "ClientLocationName" },
                values: new object[,]
                {
                    { 1, "Boston" },
                    { 2, "New Delhi" },
                    { 3, "New Jersey" },
                    { 4, "New York" },
                    { 5, "London" },
                    { 6, "Tokyo" }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 1,
                columns: new[] { "Active", "ClientLocationId", "Status" },
                values: new object[] { true, 1, "In Force" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 2,
                columns: new[] { "Active", "ClientLocationId", "Status" },
                values: new object[] { true, 2, "In Force" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 3,
                columns: new[] { "Active", "ClientLocationId", "Status" },
                values: new object[] { true, 3, "In Force" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 4,
                columns: new[] { "Active", "ClientLocationId", "Status" },
                values: new object[] { true, 4, "Support" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 5,
                columns: new[] { "Active", "ClientLocationId", "Status" },
                values: new object[] { true, 5, "Support" });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientLocationId",
                table: "Projects",
                column: "ClientLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ClientLocations_ClientLocationId",
                table: "Projects",
                column: "ClientLocationId",
                principalTable: "ClientLocations",
                principalColumn: "ClientLocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ClientLocations_ClientLocationId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ClientLocations");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ClientLocationId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ClientLocationId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "TeamSize",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
