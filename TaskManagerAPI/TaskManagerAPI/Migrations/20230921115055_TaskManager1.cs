using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class TaskManager1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectID",
                keyValue: 5);
        }
    }
}
