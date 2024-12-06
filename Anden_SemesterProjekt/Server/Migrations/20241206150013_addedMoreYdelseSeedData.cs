using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class addedMoreYdelseSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 32,
                column: "Pris",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 36,
                column: "Pris",
                value: 280.0);

            migrationBuilder.InsertData(
                table: "Varer",
                columns: new[] { "Id", "Beskrivelse", "ErAktiv", "Pris" },
                values: new object[,]
                {
                    { 22, "Reparation (u/ reservedele)", true, 200.0 },
                    { 37, "Vask", true, 100.0 }
                });

            migrationBuilder.UpdateData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 36,
                column: "AntalTimer",
                value: 1.0);

            migrationBuilder.InsertData(
                table: "Ydelser",
                columns: new[] { "Id", "AntalTimer" },
                values: new object[,]
                {
                    { 22, 1.0 },
                    { 37, 0.25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.UpdateData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 32,
                column: "Pris",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 36,
                column: "Pris",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 36,
                column: "AntalTimer",
                value: 0.5);
        }
    }
}
