using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "By",
                columns: table => new
                {
                    Postnummer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ByNavn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_By", x => x.Postnummer);
                });

            migrationBuilder.CreateTable(
                name: "Mekanikere",
                columns: table => new
                {
                    MekanikerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErAktiv = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mekanikere", x => x.MekanikerId);
                });

            migrationBuilder.CreateTable(
                name: "Mærker",
                columns: table => new
                {
                    MærkeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScooterMærke = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mærker", x => x.MærkeId);
                });

            migrationBuilder.CreateTable(
                name: "Varer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beskrivelse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pris = table.Column<double>(type: "float", nullable: false),
                    ErAktiv = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kunder",
                columns: table => new
                {
                    KundeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MekanikerId = table.Column<int>(type: "int", nullable: true),
                    ErAktiv = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunder", x => x.KundeId);
                    table.ForeignKey(
                        name: "FK_Kunder_Mekanikere_MekanikerId",
                        column: x => x.MekanikerId,
                        principalTable: "Mekanikere",
                        principalColumn: "MekanikerId");
                });

            migrationBuilder.CreateTable(
                name: "MekanikerMærke",
                columns: table => new
                {
                    MekanikerId = table.Column<int>(type: "int", nullable: false),
                    MærkeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MekanikerMærke", x => new { x.MekanikerId, x.MærkeId });
                    table.ForeignKey(
                        name: "FK_MekanikerMærke_Mekanikere_MekanikerId",
                        column: x => x.MekanikerId,
                        principalTable: "Mekanikere",
                        principalColumn: "MekanikerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MekanikerMærke_Mærker_MærkeId",
                        column: x => x.MærkeId,
                        principalTable: "Mærker",
                        principalColumn: "MærkeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scootere",
                columns: table => new
                {
                    ScooterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stelnummer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Registreringsnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MærkeId = table.Column<int>(type: "int", nullable: false),
                    ErAktiv = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scootere", x => x.ScooterId);
                    table.ForeignKey(
                        name: "FK_Scootere_Mærker_MærkeId",
                        column: x => x.MærkeId,
                        principalTable: "Mærker",
                        principalColumn: "MærkeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ydelser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AntalTimer = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ydelser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ydelser_Varer_Id",
                        column: x => x.Id,
                        principalTable: "Varer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresser",
                columns: table => new
                {
                    AdresseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gadenavn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Husnummer = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Etage = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Side = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Dørnummer = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Postnummer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KundeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresser", x => x.AdresseId);
                    table.ForeignKey(
                        name: "FK_Adresser_By_Postnummer",
                        column: x => x.Postnummer,
                        principalTable: "By",
                        principalColumn: "Postnummer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adresser_Kunder_KundeId",
                        column: x => x.KundeId,
                        principalTable: "Kunder",
                        principalColumn: "KundeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TlfNumre",
                columns: table => new
                {
                    TlfNummerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelefonNummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KundeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TlfNumre", x => x.TlfNummerId);
                    table.ForeignKey(
                        name: "FK_TlfNumre_Kunder_KundeId",
                        column: x => x.KundeId,
                        principalTable: "Kunder",
                        principalColumn: "KundeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KundeScootere",
                columns: table => new
                {
                    ScooterId = table.Column<int>(type: "int", nullable: false),
                    KundeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KundeScootere", x => x.ScooterId);
                    table.ForeignKey(
                        name: "FK_KundeScootere_Kunder_KundeId",
                        column: x => x.KundeId,
                        principalTable: "Kunder",
                        principalColumn: "KundeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KundeScootere_Scootere_ScooterId",
                        column: x => x.ScooterId,
                        principalTable: "Scootere",
                        principalColumn: "ScooterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UdlejningsScootere",
                columns: table => new
                {
                    ScooterId = table.Column<int>(type: "int", nullable: false),
                    ErTilgængelig = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UdlejningsScootere", x => x.ScooterId);
                    table.ForeignKey(
                        name: "FK_UdlejningsScootere_Scootere_ScooterId",
                        column: x => x.ScooterId,
                        principalTable: "Scootere",
                        principalColumn: "ScooterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordrer",
                columns: table => new
                {
                    OrdreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KundeId = table.Column<int>(type: "int", nullable: false),
                    KundeScooterId = table.Column<int>(type: "int", nullable: true),
                    BetalingsDato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ErBetalt = table.Column<bool>(type: "bit", nullable: false),
                    ErAfsluttet = table.Column<bool>(type: "bit", nullable: false),
                    StartDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MekanikerId = table.Column<int>(type: "int", nullable: true),
                    Bemærkninger = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordrer", x => x.OrdreId);
                    table.ForeignKey(
                        name: "FK_Ordrer_KundeScootere_KundeScooterId",
                        column: x => x.KundeScooterId,
                        principalTable: "KundeScootere",
                        principalColumn: "ScooterId");
                    table.ForeignKey(
                        name: "FK_Ordrer_Kunder_KundeId",
                        column: x => x.KundeId,
                        principalTable: "Kunder",
                        principalColumn: "KundeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordrer_Mekanikere_MekanikerId",
                        column: x => x.MekanikerId,
                        principalTable: "Mekanikere",
                        principalColumn: "MekanikerId");
                });

            migrationBuilder.CreateTable(
                name: "Udlejninger",
                columns: table => new
                {
                    UdlejningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UdlejningsScooterId = table.Column<int>(type: "int", nullable: false),
                    OrdreId = table.Column<int>(type: "int", nullable: false),
                    StartDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AntalKmKørt = table.Column<double>(type: "float", nullable: false),
                    SelvrisikoUdløst = table.Column<bool>(type: "bit", nullable: false),
                    LejePrDag = table.Column<double>(type: "float", nullable: false),
                    ForsikringPrDag = table.Column<double>(type: "float", nullable: false),
                    PrisPrKm = table.Column<double>(type: "float", nullable: false),
                    Selvrisiko = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Udlejninger", x => x.UdlejningId);
                    table.ForeignKey(
                        name: "FK_Udlejninger_Ordrer_OrdreId",
                        column: x => x.OrdreId,
                        principalTable: "Ordrer",
                        principalColumn: "OrdreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Udlejninger_UdlejningsScootere_UdlejningsScooterId",
                        column: x => x.UdlejningsScooterId,
                        principalTable: "UdlejningsScootere",
                        principalColumn: "ScooterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VareLinjer",
                columns: table => new
                {
                    VareLinjeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdreId = table.Column<int>(type: "int", nullable: false),
                    VareId = table.Column<int>(type: "int", nullable: false),
                    Antal = table.Column<int>(type: "int", nullable: true),
                    Rabat = table.Column<double>(type: "float", nullable: true),
                    VarePris = table.Column<double>(type: "float", nullable: false),
                    VareBeskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YdelseAntalTimer = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VareLinjer", x => x.VareLinjeId);
                    table.ForeignKey(
                        name: "FK_VareLinjer_Ordrer_OrdreId",
                        column: x => x.OrdreId,
                        principalTable: "Ordrer",
                        principalColumn: "OrdreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VareLinjer_Varer_VareId",
                        column: x => x.VareId,
                        principalTable: "Varer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "By",
                columns: new[] { "Postnummer", "ByNavn" },
                values: new object[,]
                {
                    { "1000", "København" },
                    { "2000", "Frederiksberg" },
                    { "3000", "Helsingør" },
                    { "4000", "Roskilde" },
                    { "5000", "Odense" },
                    { "6000", "Kolding" },
                    { "7000", "Fredericia" },
                    { "7100", "Vejle" },
                    { "8000", "Århus" }
                });

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

            migrationBuilder.InsertData(
                table: "Mærker",
                columns: new[] { "MærkeId", "ScooterMærke" },
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

            migrationBuilder.InsertData(
                table: "MekanikerMærke",
                columns: new[] { "MekanikerId", "MærkeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 8 },
                    { 1, 10 },
                    { 2, 3 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 10 },
                    { 3, 2 },
                    { 3, 8 },
                    { 3, 9 },
                    { 3, 10 },
                    { 4, 1 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 7 },
                    { 4, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresser_KundeId",
                table: "Adresser",
                column: "KundeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adresser_Postnummer",
                table: "Adresser",
                column: "Postnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Kunder_MekanikerId",
                table: "Kunder",
                column: "MekanikerId");

            migrationBuilder.CreateIndex(
                name: "IX_KundeScootere_KundeId",
                table: "KundeScootere",
                column: "KundeId");

            migrationBuilder.CreateIndex(
                name: "IX_MekanikerMærke_MærkeId",
                table: "MekanikerMærke",
                column: "MærkeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordrer_KundeId",
                table: "Ordrer",
                column: "KundeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordrer_KundeScooterId",
                table: "Ordrer",
                column: "KundeScooterId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordrer_MekanikerId",
                table: "Ordrer",
                column: "MekanikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Scootere_MærkeId",
                table: "Scootere",
                column: "MærkeId");

            migrationBuilder.CreateIndex(
                name: "IX_TlfNumre_KundeId",
                table: "TlfNumre",
                column: "KundeId");

            migrationBuilder.CreateIndex(
                name: "IX_Udlejninger_OrdreId",
                table: "Udlejninger",
                column: "OrdreId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Udlejninger_UdlejningsScooterId",
                table: "Udlejninger",
                column: "UdlejningsScooterId");

            migrationBuilder.CreateIndex(
                name: "IX_VareLinjer_OrdreId",
                table: "VareLinjer",
                column: "OrdreId");

            migrationBuilder.CreateIndex(
                name: "IX_VareLinjer_VareId",
                table: "VareLinjer",
                column: "VareId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresser");

            migrationBuilder.DropTable(
                name: "MekanikerMærke");

            migrationBuilder.DropTable(
                name: "TlfNumre");

            migrationBuilder.DropTable(
                name: "Udlejninger");

            migrationBuilder.DropTable(
                name: "VareLinjer");

            migrationBuilder.DropTable(
                name: "Ydelser");

            migrationBuilder.DropTable(
                name: "By");

            migrationBuilder.DropTable(
                name: "UdlejningsScootere");

            migrationBuilder.DropTable(
                name: "Ordrer");

            migrationBuilder.DropTable(
                name: "Varer");

            migrationBuilder.DropTable(
                name: "KundeScootere");

            migrationBuilder.DropTable(
                name: "Kunder");

            migrationBuilder.DropTable(
                name: "Scootere");

            migrationBuilder.DropTable(
                name: "Mekanikere");

            migrationBuilder.DropTable(
                name: "Mærker");
        }
    }
}
