using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class jans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordrer_KundeScootere_KundeScooterId",
                table: "Ordrer");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordrer_UdlejningsScootere_UdlejningsScooterId",
                table: "Ordrer");

            migrationBuilder.DropForeignKey(
                name: "FK_Udlejninger_UdlejningsScootere_UdlejningsScooterId",
                table: "Udlejninger");

            migrationBuilder.DropTable(
                name: "KundeScootere");

            migrationBuilder.DropTable(
                name: "UdlejningsScootere");

            migrationBuilder.AddColumn<bool>(
                name: "ErTilgængelig",
                table: "Scootere",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KundeId",
                table: "Scootere",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScooterType",
                table: "Scootere",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Scootere_KundeId",
                table: "Scootere",
                column: "KundeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordrer_Scootere_KundeScooterId",
                table: "Ordrer",
                column: "KundeScooterId",
                principalTable: "Scootere",
                principalColumn: "ScooterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordrer_Scootere_UdlejningsScooterId",
                table: "Ordrer",
                column: "UdlejningsScooterId",
                principalTable: "Scootere",
                principalColumn: "ScooterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scootere_Kunder_KundeId",
                table: "Scootere",
                column: "KundeId",
                principalTable: "Kunder",
                principalColumn: "KundeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Udlejninger_Scootere_UdlejningsScooterId",
                table: "Udlejninger",
                column: "UdlejningsScooterId",
                principalTable: "Scootere",
                principalColumn: "ScooterId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordrer_Scootere_KundeScooterId",
                table: "Ordrer");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordrer_Scootere_UdlejningsScooterId",
                table: "Ordrer");

            migrationBuilder.DropForeignKey(
                name: "FK_Scootere_Kunder_KundeId",
                table: "Scootere");

            migrationBuilder.DropForeignKey(
                name: "FK_Udlejninger_Scootere_UdlejningsScooterId",
                table: "Udlejninger");

            migrationBuilder.DropIndex(
                name: "IX_Scootere_KundeId",
                table: "Scootere");

            migrationBuilder.DropColumn(
                name: "ErTilgængelig",
                table: "Scootere");

            migrationBuilder.DropColumn(
                name: "KundeId",
                table: "Scootere");

            migrationBuilder.DropColumn(
                name: "ScooterType",
                table: "Scootere");

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

            migrationBuilder.CreateIndex(
                name: "IX_KundeScootere_KundeId",
                table: "KundeScootere",
                column: "KundeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordrer_KundeScootere_KundeScooterId",
                table: "Ordrer",
                column: "KundeScooterId",
                principalTable: "KundeScootere",
                principalColumn: "ScooterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordrer_UdlejningsScootere_UdlejningsScooterId",
                table: "Ordrer",
                column: "UdlejningsScooterId",
                principalTable: "UdlejningsScootere",
                principalColumn: "ScooterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Udlejninger_UdlejningsScootere_UdlejningsScooterId",
                table: "Udlejninger",
                column: "UdlejningsScooterId",
                principalTable: "UdlejningsScootere",
                principalColumn: "ScooterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
