using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class addedMekanikerHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Mekanikere",
                columns: new[] { "MekanikerId", "ErAktiv", "Navn" },
                values: new object[,]
                {
                    { 1, true, "Troels Nielsen" },
                    { 2, true, "Mads Jensen" },
                    { 3, true, "Mikkel Larsen" },
                    { 4, true, "Anders Pedersen" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Mekanikere",
                keyColumn: "MekanikerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mekanikere",
                keyColumn: "MekanikerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mekanikere",
                keyColumn: "MekanikerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Mekanikere",
                keyColumn: "MekanikerId",
                keyValue: 4);
        }
    }
}
