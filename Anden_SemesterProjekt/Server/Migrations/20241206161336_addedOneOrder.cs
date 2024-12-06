using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class addedOneOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 1,
                column: "MekanikerId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Ordrer",
                columns: new[] { "OrdreId", "Bemærkninger", "BetalingsDato", "ErAfsluttet", "ErBetalt", "KundeId", "KundeScooterId", "MekanikerId", "SlutDato", "StartDato" },
                values: new object[] { 1, "", new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, 1, 1, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Udlejninger",
                columns: new[] { "UdlejningId", "AntalKmKørt", "ForsikringPrDag", "LejePrDag", "OrdreId", "PrisPrKm", "Selvrisiko", "SelvrisikoUdløst", "SlutDato", "StartDato", "UdlejningsScooterId" },
                values: new object[] { 1, 14.0, 100.0, 200.0, 1, 0.53000000000000003, 1000.0, false, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17 });

            migrationBuilder.InsertData(
                table: "VareLinjer",
                columns: new[] { "VareLinjeId", "Antal", "OrdreId", "Rabat", "VareBeskrivelse", "VareId", "VarePris", "YdelseAntalTimer" },
                values: new object[] { 1, 1, 1, 50.0, "Service", 21, 500.0, 4.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Udlejninger",
                keyColumn: "UdlejningId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VareLinjer",
                keyColumn: "VareLinjeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ordrer",
                keyColumn: "OrdreId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 1,
                column: "MekanikerId",
                value: 2);
        }
    }
}
