using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "By",
                columns: table => new
                {
                    Postnummer = table.Column<int>(type: "int", nullable: false),
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
                name: "ScooterMærke",
                columns: table => new
                {
                    MærkeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScooterMærke = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mærke", x => x.MærkeId);
                });

            migrationBuilder.CreateTable(
                name: "Varer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TilknyttetMekanikerMekanikerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunder", x => x.KundeId);
                    table.ForeignKey(
                        name: "FK_Kunder_Mekanikere_TilknyttetMekanikerMekanikerId",
                        column: x => x.TilknyttetMekanikerMekanikerId,
                        principalTable: "Mekanikere",
                        principalColumn: "MekanikerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MekanikerMærke",
                columns: table => new
                {
                    MekanikereMekanikerId = table.Column<int>(type: "int", nullable: false),
                    MærkerMærkeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MekanikerMærke", x => new { x.MekanikereMekanikerId, x.MærkerMærkeId });
                    table.ForeignKey(
                        name: "FK_MekanikerMærke_Mekanikere_MekanikereMekanikerId",
                        column: x => x.MekanikereMekanikerId,
                        principalTable: "Mekanikere",
                        principalColumn: "MekanikerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MekanikerMærke_Mærke_MærkerMærkeId",
                        column: x => x.MærkerMærkeId,
                        principalTable: "ScooterMærke",
                        principalColumn: "MærkeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scootere",
                columns: table => new
                {
                    ScooterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stelnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registreiringsnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MærkeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scootere", x => x.ScooterId);
                    table.ForeignKey(
                        name: "FK_Scootere_Mærke_MærkeId",
                        column: x => x.MærkeId,
                        principalTable: "ScooterMærke",
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
                    Gadenavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Husnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Etage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Side = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dørnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ByPostnummer = table.Column<int>(type: "int", nullable: false),
                    KundeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresser", x => x.AdresseId);
                    table.ForeignKey(
                        name: "FK_Adresser_By_ByPostnummer",
                        column: x => x.ByPostnummer,
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
                    ErTilgængelig = table.Column<bool>(type: "bit", nullable: false),
                    ErAktiv = table.Column<bool>(type: "bit", nullable: false)
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
                    KundeId = table.Column<int>(type: "int", nullable: true),
                    ScooterId = table.Column<int>(type: "int", nullable: true),
                    KundeScooterScooterId = table.Column<int>(type: "int", nullable: true),
                    BetalingsDato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ErBetalt = table.Column<bool>(type: "bit", nullable: false),
                    ErAfsluttet = table.Column<bool>(type: "bit", nullable: false),
                    StartDato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SlutDato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UdlejningsScooterId = table.Column<int>(type: "int", nullable: true),
                    MekanikerId = table.Column<int>(type: "int", nullable: true),
                    Bemærkninger = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordrer", x => x.OrdreId);
                    table.ForeignKey(
                        name: "FK_Ordrer_KundeScootere_KundeScooterScooterId",
                        column: x => x.KundeScooterScooterId,
                        principalTable: "KundeScootere",
                        principalColumn: "ScooterId");
                    table.ForeignKey(
                        name: "FK_Ordrer_Kunder_KundeId",
                        column: x => x.KundeId,
                        principalTable: "Kunder",
                        principalColumn: "KundeId");
                    table.ForeignKey(
                        name: "FK_Ordrer_Mekanikere_MekanikerId",
                        column: x => x.MekanikerId,
                        principalTable: "Mekanikere",
                        principalColumn: "MekanikerId");
                    table.ForeignKey(
                        name: "FK_Ordrer_UdlejningsScootere_UdlejningsScooterId",
                        column: x => x.UdlejningsScooterId,
                        principalTable: "UdlejningsScootere",
                        principalColumn: "ScooterId");
                });

            migrationBuilder.CreateTable(
                name: "Udlejninger",
                columns: table => new
                {
                    UdlejningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScooterId = table.Column<int>(type: "int", nullable: false),
                    UdlejningsScooterScooterId = table.Column<int>(type: "int", nullable: false),
                    OrdreId = table.Column<int>(type: "int", nullable: false),
                    StartDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutDato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AntalKmKørt = table.Column<double>(type: "float", nullable: false),
                    SelvrisikoUdløst = table.Column<bool>(type: "bit", nullable: false),
                    lejePrDag = table.Column<double>(type: "float", nullable: false),
                    forsikringPrDag = table.Column<double>(type: "float", nullable: false),
                    prisPrKm = table.Column<double>(type: "float", nullable: false),
                    selvrisiko = table.Column<double>(type: "float", nullable: false)
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
                        name: "FK_Udlejninger_UdlejningsScootere_UdlejningsScooterScooterId",
                        column: x => x.UdlejningsScooterScooterId,
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
                    Antal = table.Column<int>(type: "int", nullable: false),
                    Rabat = table.Column<double>(type: "float", nullable: true),
                    VarePris = table.Column<double>(type: "float", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Adresser_ByPostnummer",
                table: "Adresser",
                column: "ByPostnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Adresser_KundeId",
                table: "Adresser",
                column: "KundeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kunder_TilknyttetMekanikerMekanikerId",
                table: "Kunder",
                column: "TilknyttetMekanikerMekanikerId");

            migrationBuilder.CreateIndex(
                name: "IX_KundeScootere_KundeId",
                table: "KundeScootere",
                column: "KundeId");

            migrationBuilder.CreateIndex(
                name: "IX_MekanikerMærke_MærkerMærkeId",
                table: "MekanikerMærke",
                column: "MærkerMærkeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordrer_KundeId",
                table: "Ordrer",
                column: "KundeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordrer_KundeScooterScooterId",
                table: "Ordrer",
                column: "KundeScooterScooterId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordrer_MekanikerId",
                table: "Ordrer",
                column: "MekanikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordrer_UdlejningsScooterId",
                table: "Ordrer",
                column: "UdlejningsScooterId");

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
                column: "OrdreId");

            migrationBuilder.CreateIndex(
                name: "IX_Udlejninger_UdlejningsScooterScooterId",
                table: "Udlejninger",
                column: "UdlejningsScooterScooterId");

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
                name: "Ordrer");

            migrationBuilder.DropTable(
                name: "Varer");

            migrationBuilder.DropTable(
                name: "KundeScootere");

            migrationBuilder.DropTable(
                name: "UdlejningsScootere");

            migrationBuilder.DropTable(
                name: "Kunder");

            migrationBuilder.DropTable(
                name: "Scootere");

            migrationBuilder.DropTable(
                name: "Mekanikere");

            migrationBuilder.DropTable(
                name: "ScooterMærke");
        }
    }
}
