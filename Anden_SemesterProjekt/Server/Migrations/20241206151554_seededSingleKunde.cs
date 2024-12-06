using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class seededSingleKunde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kunder",
                columns: new[] { "KundeId", "Email", "ErAktiv", "MekanikerId", "Navn" },
                values: new object[] { 1, "TrNi@mail.dk", true, 2, "Troels Nielsen" });

            migrationBuilder.InsertData(
                table: "Scootere",
                columns: new[] { "ScooterId", "ErAktiv", "MærkeId", "Registreringsnummer", "Stelnummer" },
                values: new object[] { 1, true, 1, "HB3827", "Kj37h3GS9jOpI800" });

            migrationBuilder.InsertData(
                table: "Adresser",
                columns: new[] { "AdresseId", "Dørnummer", "Etage", "Gadenavn", "Husnummer", "KundeId", "Postnummer", "Side" },
                values: new object[] { 1, "", "3", "Hovedgaden", "34", 1, "6000", "tv" });

            migrationBuilder.InsertData(
                table: "KundeScootere",
                columns: new[] { "ScooterId", "KundeId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "TlfNumre",
                columns: new[] { "TlfNummerId", "KundeId", "TelefonNummer" },
                values: new object[,]
                {
                    { 1, 1, "12345678" },
                    { 2, 1, "87654321" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Adresser",
                keyColumn: "AdresseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 1);
        }
    }
}
