using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class addedNewSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Varer",
                columns: new[] { "Id", "Beskrivelse", "ErAktiv", "Pris" },
                values: new object[,]
                {
                    { 1, "Hjelm", true, 500.0 },
                    { 2, "Handsker", true, 200.0 },
                    { 3, "Jakke", true, 800.0 },
                    { 4, "Bukser", true, 600.0 },
                    { 5, "Støvler", true, 400.0 },
                    { 6, "Motorolie", true, 200.0 },
                    { 7, "Pære (hvid)", true, 300.0 },
                    { 8, "Pære (rød)", true, 100.0 },
                    { 9, "Pære (orange)", true, 200.0 },
                    { 10, "Tændrør", true, 50.0 },
                    { 11, "Batteri", true, 300.0 },
                    { 12, "Dæk", true, 500.0 },
                    { 13, "Fælg", true, 400.0 },
                    { 14, "Kædeskærm", true, 100.0 },
                    { 15, "Kæde", true, 200.0 },
                    { 16, "Mobil holder", true, 100.0 },
                    { 17, "GPS", true, 300.0 },
                    { 18, "Bluetooth headset", true, 200.0 },
                    { 19, "Rygstøtte", true, 100.0 },
                    { 20, "Topboks", true, 500.0 },
                    { 21, "Service", true, 500.0 },
                    { 23, "Syn", true, 300.0 },
                    { 24, "Dækskift", true, 100.0 },
                    { 25, "Bremse service", true, 300.0 },
                    { 26, "Motor service", true, 800.0 },
                    { 27, "Elmotor service", true, 700.0 },
                    { 28, "Fejlfinding", true, 200.0 },
                    { 29, "Rustbeskyttelse", true, 1400.0 },
                    { 30, "Lakering", true, 2000.0 },
                    { 31, "Polering", true, 500.0 },
                    { 32, "Rengøring", true, 200.0 },
                    { 33, "Dæktryk tjek", true, 50.0 },
                    { 34, "Kæde smøring", true, 80.0 },
                    { 35, "Kæde stramning", true, 100.0 },
                    { 36, "Kæde skift", true, 200.0 }
                });

            migrationBuilder.InsertData(
                table: "Ydelser",
                columns: new[] { "Id", "AntalTimer" },
                values: new object[,]
                {
                    { 21, 4.0 },
                    { 23, 1.0 },
                    { 24, 0.25 },
                    { 25, 1.0 },
                    { 26, 3.0 },
                    { 27, 3.0 },
                    { 28, 1.0 },
                    { 29, 6.0 },
                    { 30, 8.0 },
                    { 31, 2.0 },
                    { 32, 1.0 },
                    { 33, 0.14999999999999999 },
                    { 34, 0.20000000000000001 },
                    { 35, 0.25 },
                    { 36, 0.5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 36);
        }
    }
}
