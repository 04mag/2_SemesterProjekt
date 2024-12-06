using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class seededKunder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kunder",
                columns: new[] { "KundeId", "Email", "ErAktiv", "MekanikerId", "Navn" },
                values: new object[,]
                {
                    { 2, "AnnaH@mail.dk", true, 3, "Anna Hansen" },
                    { 3, "PeJe@mail.dk", true, 1, "Peter Jensen" },
                    { 4, "LaNi@mail.dk", true, 4, "Lars Nielsen" },
                    { 5, "MeSo@mail.dk", true, 2, "Mette Sørensen" },
                    { 6, "KaAn@mail.dk", true, 3, "Kasper Andersen" },
                    { 7, "SoPe@mail.dk", true, 3, "Sofie Pedersen" },
                    { 8, "JoKr@mail.dk", true, 1, "Jonas Kristensen" },
                    { 9, "CaTh@mail.dk", true, 4, "Camilla Thomsen" },
                    { 10, "FrRa@mail.dk", true, 1, "Frederik Rasmussen" },
                    { 11, "TrNi@mail.dk", true, 2, "Troels Nielsen" },
                    { 12, "MaLa@mail.dk", true, 3, "Maja Larsen" },
                    { 13, "NiMo@mail.dk", true, 2, "Nikolaj Møller" },
                    { 14, "JuOl@mail.dk", true, 1, "Julie Olesen" },
                    { 15, "HePo@mail.dk", true, 4, "Henrik Poulsen" },
                    { 16, "KaHo@mail.dk", true, 3, "Katrine Holm" }
                });

            migrationBuilder.UpdateData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 1,
                column: "Stelnummer",
                value: "Kj37h3GS9jOpI800J");

            migrationBuilder.InsertData(
                table: "Scootere",
                columns: new[] { "ScooterId", "ErAktiv", "MærkeId", "Registreringsnummer", "Stelnummer" },
                values: new object[,]
                {
                    { 2, true, 2, "VB7382", "1HGBH41JXMN109186" },
                    { 3, true, 3, "AF3234", "2HGCM82633A004352" },
                    { 4, true, 4, "CD5634", "1HGCM82633A004353" },
                    { 5, true, 5, "EF9072", "JH4KA8260MC000000" },
                    { 6, true, 6, "GH3656", "1HGCM82633A004354" },
                    { 7, true, 7, "IJ7630", "2HGCM82633A004355" },
                    { 8, true, 8, "KL1533", "1HGCM82633A004356" },
                    { 9, true, 9, "MN2648", "JH4KA8260MC000001" },
                    { 10, true, 10, "OP9314", "1HGCM82633A004357" },
                    { 11, true, 1, "QR5452", "2HGCM82633A004358" },
                    { 12, true, 2, "ST3850", "1HGCM82633A004359" },
                    { 13, true, 3, "UV2254", "JH4KA8260MC000002" },
                    { 14, true, 4, "WX5375", "1HGCM82633A004360" },
                    { 15, true, 5, "YZ3052", "2HGCM82633A004361" },
                    { 16, true, 6, "AB3651", "1HGCM82633A004362" }
                });

            migrationBuilder.UpdateData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 1,
                column: "TelefonNummer",
                value: "34345678");

            migrationBuilder.UpdateData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 2,
                column: "TelefonNummer",
                value: "47254321");

            migrationBuilder.InsertData(
                table: "Adresser",
                columns: new[] { "AdresseId", "Dørnummer", "Etage", "Gadenavn", "Husnummer", "KundeId", "Postnummer", "Side" },
                values: new object[,]
                {
                    { 2, "23", "2", "Borgergade", "12", 2, "7100", "" },
                    { 3, "", "", "Vestergade", "45", 3, "7000", "" },
                    { 4, "10", "1", "Nørregade", "78", 4, "7100", "mf" },
                    { 5, "", "4", "Østergade", "22", 5, "6000", "th" },
                    { 6, "5", "", "Søndergade", "56", 6, "7100", "" },
                    { 7, "8", "2", "Kirkegade", "15", 7, "6000", "tv" },
                    { 8, "", "3", "Skolegade", "9", 8, "7000", "th" },
                    { 9, "12", "", "Algade", "27", 9, "7100", "" },
                    { 10, "", "1", "Møllevej", "33", 10, "6000", "mf" },
                    { 11, "7", "4", "Bakkevej", "5", 11, "7000", "tv" },
                    { 12, "3", "", "Engvej", "18", 12, "7100", "" },
                    { 13, "", "2", "Lærkevej", "21", 13, "6000", "th" },
                    { 14, "9", "3", "Birkevej", "44", 14, "7000", "mf" },
                    { 15, "6", "", "Fasanvej", "30", 15, "7100", "" },
                    { 16, "", "1", "Solbakken", "12", 16, "6000", "tv" }
                });

            migrationBuilder.InsertData(
                table: "KundeScootere",
                columns: new[] { "ScooterId", "KundeId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 11 },
                    { 12, 12 },
                    { 13, 13 },
                    { 14, 14 },
                    { 15, 15 },
                    { 16, 16 }
                });

            migrationBuilder.InsertData(
                table: "TlfNumre",
                columns: new[] { "TlfNummerId", "KundeId", "TelefonNummer" },
                values: new object[,]
                {
                    { 3, 2, "23456789" },
                    { 4, 3, "34567890" },
                    { 5, 4, "45678901" },
                    { 6, 5, "56789012" },
                    { 7, 6, "67890123" },
                    { 8, 7, "78901234" },
                    { 9, 8, "89012345" },
                    { 10, 9, "90123456" },
                    { 11, 10, "23456780" },
                    { 12, 11, "34567891" },
                    { 13, 12, "45678902" },
                    { 14, 13, "56789013" },
                    { 15, 14, "67890124" },
                    { 16, 15, "78901235" },
                    { 17, 16, "89012346" },
                    { 18, 2, "90123457" },
                    { 19, 3, "23456781" },
                    { 20, 4, "34567892" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Adresser",
                keyColumn: "AdresseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Adresser",
                keyColumn: "AdresseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Adresser",
                keyColumn: "AdresseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Adresser",
                keyColumn: "AdresseId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Adresser",
                keyColumn: "AdresseId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Adresser",
                keyColumn: "AdresseId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Adresser",
                keyColumn: "AdresseId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Adresser",
                keyColumn: "AdresseId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Adresser",
                keyColumn: "AdresseId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Adresser",
                keyColumn: "AdresseId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Adresser",
                keyColumn: "AdresseId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Adresser",
                keyColumn: "AdresseId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Adresser",
                keyColumn: "AdresseId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Adresser",
                keyColumn: "AdresseId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Adresser",
                keyColumn: "AdresseId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 1,
                column: "Stelnummer",
                value: "Kj37h3GS9jOpI800");

            migrationBuilder.UpdateData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 1,
                column: "TelefonNummer",
                value: "12345678");

            migrationBuilder.UpdateData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 2,
                column: "TelefonNummer",
                value: "87654321");
        }
    }
}
