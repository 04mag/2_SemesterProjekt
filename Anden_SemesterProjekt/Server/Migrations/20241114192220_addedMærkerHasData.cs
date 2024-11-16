using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class addedMærkerHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Mærker",
                columns: new[] { "MærkeId", "Mærke" },
                values: new object[,]
                {
                    { 1, "Aprilla" },
                    { 2, "Derbi" },
                    { 3, "Karma" },
                    { 4, "Lindebjerg" },
                    { 5, "Pegasus" },
                    { 6, "Peugeot" },
                    { 7, "PGO" },
                    { 8, "Puch" },
                    { 9, "Vespa" },
                    { 10, "Yamaha" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 10);
        }
    }
}
