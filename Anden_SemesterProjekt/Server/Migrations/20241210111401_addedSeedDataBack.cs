using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class addedSeedDataBack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kunder",
                columns: new[] { "KundeId", "Email", "ErAktiv", "MekanikerId", "Navn" },
                values: new object[,]
                {
                    { 1, "TrNi@mail.dk", true, 1, "Troels Nielsen" },
                    { 2, "AnnaH@mail.dk", true, 3, "Anna Hansen" },
                    { 3, "PeJe@mail.dk", true, 1, "Peter Jensen" },
                    { 4, "LaNi@mail.dk", true, 4, "Lars Nielsen" },
                    { 5, "MeSo@mail.dk", true, 2, "Mette Sørensen" },
                    { 6, "KaAn@mail.dk", true, 3, "Kasper Andersen" },
                    { 7, "SoPe@mail.dk", true, 3, "Sofie Pedersen" },
                    { 8, "JoKr@mail.dk", true, 1, "Jonas Kristensen" },
                    { 9, "CaTh@mail.dk", true, 4, "Camilla Thomsen" },
                    { 10, "FrRa@mail.dk", true, 1, "Frederik Rasmussen" },
                    { 11, "JensNielsen@mail.dk", true, 2, "Jens Nielsen" },
                    { 12, "MaLa@mail.dk", true, 3, "Maja Larsen" },
                    { 13, "NiMo@mail.dk", true, 2, "Nikolaj Møller" },
                    { 14, "JuOl@mail.dk", true, 1, "Julie Olesen" },
                    { 15, "HePo@mail.dk", true, 4, "Henrik Poulsen" },
                    { 16, "KaHo@mail.dk", true, 3, "Katrine Holm" }
                });

            migrationBuilder.InsertData(
                table: "Scootere",
                columns: new[] { "ScooterId", "ErAktiv", "MærkeId", "Registreringsnummer", "Stelnummer" },
                values: new object[,]
                {
                    { 1, true, 1, "HB3827", "Kj37h3GS9jOpI800J" },
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
                    { 16, true, 6, "AB3651", "1HGCM82633A004362" },
                    { 17, true, 1, "CD3654", "1HGCM82633A004363" },
                    { 18, true, 1, "EF9073", "2HGCM82633A004364" },
                    { 19, true, 1, "GH1234", "3HGCM82633A004365" },
                    { 20, true, 1, "IJ5678", "4HGCM82633A004366" },
                    { 21, true, 1, "KL9012", "5HGCM82633A004367" },
                    { 22, true, 1, "MN3456", "6HGCM82633A004368" },
                    { 23, true, 1, "OP7890", "7HGCM82633A004369" }
                });

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
                    { 22, "Reparation (u/ reservedele)", true, 200.0 },
                    { 23, "Syn", true, 300.0 },
                    { 24, "Dækskift", true, 100.0 },
                    { 25, "Bremse service", true, 300.0 },
                    { 26, "Motor service", true, 800.0 },
                    { 27, "Elmotor service", true, 700.0 },
                    { 28, "Fejlfinding", true, 200.0 },
                    { 29, "Rustbeskyttelse", true, 1400.0 },
                    { 30, "Lakering", true, 2000.0 },
                    { 31, "Polering", true, 500.0 },
                    { 32, "Rengøring", true, 250.0 },
                    { 33, "Dæktryk tjek", true, 50.0 },
                    { 34, "Kæde smøring", true, 80.0 },
                    { 35, "Kæde stramning", true, 100.0 },
                    { 36, "Kæde skift", true, 280.0 },
                    { 37, "Vask", true, 100.0 }
                });

            migrationBuilder.InsertData(
                table: "Adresser",
                columns: new[] { "AdresseId", "Dørnummer", "Etage", "Gadenavn", "Husnummer", "KundeId", "Postnummer", "Side" },
                values: new object[,]
                {
                    { 1, "", "3", "Hovedgaden", "34", 1, "6000", "tv" },
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
                    { 1, 1 },
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
                table: "Ordrer",
                columns: new[] { "OrdreId", "Bemærkninger", "BetalingsDato", "ErAfsluttet", "ErBetalt", "KundeId", "KundeScooterId", "MekanikerId", "SlutDato", "StartDato" },
                values: new object[] { 3, "", null, true, false, 10, null, null, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "TlfNumre",
                columns: new[] { "TlfNummerId", "KundeId", "TelefonNummer" },
                values: new object[,]
                {
                    { 1, 1, "34345678" },
                    { 2, 1, "47254321" },
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

            migrationBuilder.InsertData(
                table: "UdlejningsScootere",
                columns: new[] { "ScooterId", "ErTilgængelig" },
                values: new object[,]
                {
                    { 17, true },
                    { 18, true },
                    { 19, false },
                    { 20, true },
                    { 21, true },
                    { 22, true },
                    { 23, true }
                });

            migrationBuilder.InsertData(
                table: "Ydelser",
                columns: new[] { "Id", "AntalTimer" },
                values: new object[,]
                {
                    { 21, 4.0 },
                    { 22, 1.0 },
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
                    { 36, 1.0 },
                    { 37, 0.25 }
                });

            migrationBuilder.InsertData(
                table: "Ordrer",
                columns: new[] { "OrdreId", "Bemærkninger", "BetalingsDato", "ErAfsluttet", "ErBetalt", "KundeId", "KundeScooterId", "MekanikerId", "SlutDato", "StartDato" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, 1, 1, 1, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Dækskifte til nye dæk, samt skifte af kæde.", null, false, false, 4, 4, 4, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "VareLinjer",
                columns: new[] { "VareLinjeId", "Antal", "OrdreId", "Rabat", "VareBeskrivelse", "VareId", "VarePris", "YdelseAntalTimer" },
                values: new object[,]
                {
                    { 5, 1, 3, 0.0, "Hjelm", 1, 500.0, 0.0 },
                    { 6, 1, 3, 200.0, "Handsker", 2, 200.0, 0.0 },
                    { 7, 1, 3, 0.0, "Jakke", 3, 800.0, 0.0 },
                    { 8, 1, 3, 0.0, "Bukser", 4, 600.0, 0.0 },
                    { 9, 1, 3, 0.0, "Støvler", 5, 400.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Udlejninger",
                columns: new[] { "UdlejningId", "AntalKmKørt", "ForsikringPrDag", "LejePrDag", "OrdreId", "PrisPrKm", "Selvrisiko", "SelvrisikoUdløst", "SlutDato", "StartDato", "UdlejningsScooterId" },
                values: new object[,]
                {
                    { 1, 14.0, 100.0, 200.0, 1, 0.53000000000000003, 1000.0, true, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17 },
                    { 2, 0.0, 100.0, 200.0, 2, 0.53000000000000003, 1000.0, false, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), 19 }
                });

            migrationBuilder.InsertData(
                table: "VareLinjer",
                columns: new[] { "VareLinjeId", "Antal", "OrdreId", "Rabat", "VareBeskrivelse", "VareId", "VarePris", "YdelseAntalTimer" },
                values: new object[,]
                {
                    { 1, 1, 1, 50.0, "Service", 21, 500.0, 4.0 },
                    { 2, 2, 2, 0.0, "Dæk", 12, 500.0, 0.0 },
                    { 3, 2, 2, 25.0, "Dækskifte", 24, 100.0, 0.25 },
                    { 4, 1, 2, 0.0, "Kæde skift", 36, 280.0, 1.0 }
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
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TlfNumre",
                keyColumn: "TlfNummerId",
                keyValue: 2);

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
                table: "Udlejninger",
                keyColumn: "UdlejningId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Udlejninger",
                keyColumn: "UdlejningId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UdlejningsScootere",
                keyColumn: "ScooterId",
                keyValue: 18);

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
                table: "VareLinjer",
                keyColumn: "VareLinjeId",
                keyValue: 1);

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
                keyValue: 22);

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
                table: "Ydelser",
                keyColumn: "Id",
                keyValue: 37);

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
                table: "Ordrer",
                keyColumn: "OrdreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ordrer",
                keyColumn: "OrdreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ordrer",
                keyColumn: "OrdreId",
                keyValue: 3);

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

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 18);

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

            migrationBuilder.DeleteData(
                table: "UdlejningsScootere",
                keyColumn: "ScooterId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "UdlejningsScootere",
                keyColumn: "ScooterId",
                keyValue: 19);

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
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 22);

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

            migrationBuilder.DeleteData(
                table: "Varer",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KundeScootere",
                keyColumn: "ScooterId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Scootere",
                keyColumn: "ScooterId",
                keyValue: 4);
        }
    }
}
