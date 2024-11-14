using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordrer_KundeScootere_KundeScooterScooterId",
                table: "Ordrer");

            migrationBuilder.DropIndex(
                name: "IX_Ordrer_KundeScooterScooterId",
                table: "Ordrer");

            migrationBuilder.DropColumn(
                name: "KundeScooterScooterId",
                table: "Ordrer");

            migrationBuilder.RenameColumn(
                name: "ScooterId",
                table: "Ordrer",
                newName: "KundeScooterId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordrer_KundeScooterId",
                table: "Ordrer",
                column: "KundeScooterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordrer_KundeScootere_KundeScooterId",
                table: "Ordrer",
                column: "KundeScooterId",
                principalTable: "KundeScootere",
                principalColumn: "ScooterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordrer_KundeScootere_KundeScooterId",
                table: "Ordrer");

            migrationBuilder.DropIndex(
                name: "IX_Ordrer_KundeScooterId",
                table: "Ordrer");

            migrationBuilder.RenameColumn(
                name: "KundeScooterId",
                table: "Ordrer",
                newName: "ScooterId");

            migrationBuilder.AddColumn<int>(
                name: "KundeScooterScooterId",
                table: "Ordrer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordrer_KundeScooterScooterId",
                table: "Ordrer",
                column: "KundeScooterScooterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordrer_KundeScootere_KundeScooterScooterId",
                table: "Ordrer",
                column: "KundeScooterScooterId",
                principalTable: "KundeScootere",
                principalColumn: "ScooterId");
        }
    }
}
