using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagerMvc.Migrations
{
    /// <inheritdoc />
    public partial class TaskManagerMvc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectID", "DateOfStart", "ProjectName", "TeamSize" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angular", 24 },
                    { 2, new DateTime(2003, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Java", 26 },
                    { 3, new DateTime(2004, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), ".Net", 28 },
                    { 4, new DateTime(2005, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "SQL", 40 },
                    { 5, new DateTime(2007, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oracle", 44 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
