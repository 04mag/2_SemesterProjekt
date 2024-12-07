using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class seededFlereOrdrer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ordrer",
                columns: new[] { "OrdreId", "Bemærkninger", "BetalingsDato", "ErAfsluttet", "ErBetalt", "KundeId", "KundeScooterId", "MekanikerId", "SlutDato", "StartDato" },
                values: new object[,]
                {
                    { 2, "Dækskifte til nye dæk, samt skifte af kæde.", null, false, false, 4, 4, 4, new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, "", null, true, false, 10, null, null, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "Udlejninger",
                keyColumn: "UdlejningId",
                keyValue: 1,
                column: "SelvrisikoUdløst",
                value: true);

            migrationBuilder.UpdateData(
                table: "UdlejningsScootere",
                keyColumn: "ScooterId",
                keyValue: 19,
                column: "ErTilgængelig",
                value: false);

            migrationBuilder.InsertData(
                table: "Udlejninger",
                columns: new[] { "UdlejningId", "AntalKmKørt", "ForsikringPrDag", "LejePrDag", "OrdreId", "PrisPrKm", "Selvrisiko", "SelvrisikoUdløst", "SlutDato", "StartDato", "UdlejningsScooterId" },
                values: new object[] { 2, 0.0, 100.0, 200.0, 2, 0.53000000000000003, 1000.0, false, new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Local), 19 });

            migrationBuilder.InsertData(
                table: "VareLinjer",
                columns: new[] { "VareLinjeId", "Antal", "OrdreId", "Rabat", "VareBeskrivelse", "VareId", "VarePris", "YdelseAntalTimer" },
                values: new object[,]
                {
                    { 2, 2, 2, 0.0, "Dæk", 12, 500.0, 0.0 },
                    { 3, 2, 2, 25.0, "Dækskifte", 24, 100.0, 0.25 },
                    { 4, 1, 2, 0.0, "Kæde skift", 36, 280.0, 1.0 },
                    { 5, 1, 3, 0.0, "Hjelm", 1, 500.0, 0.0 },
                    { 6, 1, 3, 200.0, "Handsker", 2, 200.0, 0.0 },
                    { 7, 1, 3, 0.0, "Jakke", 3, 800.0, 0.0 },
                    { 8, 1, 3, 0.0, "Bukser", 4, 600.0, 0.0 },
                    { 9, 1, 3, 0.0, "Støvler", 5, 400.0, 0.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Udlejninger",
                keyColumn: "UdlejningId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VareLinjer",
                keyColumn: "VareLinjeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VareLinjer",
                keyColumn: "VareLinjeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VareLinjer",
                keyColumn: "VareLinjeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VareLinjer",
                keyColumn: "VareLinjeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VareLinjer",
                keyColumn: "VareLinjeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VareLinjer",
                keyColumn: "VareLinjeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VareLinjer",
                keyColumn: "VareLinjeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VareLinjer",
                keyColumn: "VareLinjeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ordrer",
                keyColumn: "OrdreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ordrer",
                keyColumn: "OrdreId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Udlejninger",
                keyColumn: "UdlejningId",
                keyValue: 1,
                column: "SelvrisikoUdløst",
                value: false);

            migrationBuilder.UpdateData(
                table: "UdlejningsScootere",
                keyColumn: "ScooterId",
                keyValue: 19,
                column: "ErTilgængelig",
                value: true);
        }
    }
}
