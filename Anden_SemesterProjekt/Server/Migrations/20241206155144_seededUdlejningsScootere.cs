using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class seededUdlejningsScootere : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Scootere",
                columns: new[] { "ScooterId", "ErAktiv", "MærkeId", "Registreringsnummer", "Stelnummer" },
                values: new object[,]
                {
                    { 17, true, 1, "CD3654", "1HGCM82633A004363" },
                    { 18, true, 1, "EF9073", "2HGCM82633A004364" },
                    { 19, true, 1, "GH1234", "3HGCM82633A004365" },
                    { 20, true, 1, "IJ5678", "4HGCM82633A004366" },
                    { 21, true, 1, "KL9012", "5HGCM82633A004367" },
                    { 22, true, 1, "MN3456", "6HGCM82633A004368" },
                    { 23, true, 1, "OP7890", "7HGCM82633A004369" }
                });

            migrationBuilder.InsertData(
                table: "UdlejningsScootere",
                columns: new[] { "ScooterId", "ErTilgængelig" },
                values: new object[,]
                {
                    { 17, true },
                    { 18, true },
                    { 19, true },
                    { 20, true },
                    { 21, true },
                    { 22, true },
                    { 23, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UdlejningsScootere",
                keyColumn: "ScooterId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "UdlejningsScootere",
                keyColumn: "ScooterId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "UdlejningsScootere",
                keyColumn: "ScooterId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "UdlejningsScootere",
                keyColumn: "ScooterId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "UdlejningsScootere",
                keyColumn: "ScooterId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "UdlejningsScootere",
                keyColumn: "ScooterId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "UdlejningsScootere",
                keyColumn: "ScooterId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 23);
        }
    }
}
