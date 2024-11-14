using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToUdlejning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Udlejninger_UdlejningsScootere_UdlejningsScooterScooterId",
                table: "Udlejninger");

            migrationBuilder.DropColumn(
                name: "ScooterId",
                table: "Udlejninger");

            migrationBuilder.RenameColumn(
                name: "UdlejningsScooterScooterId",
                table: "Udlejninger",
                newName: "UdlejningsScooterId");

            migrationBuilder.RenameIndex(
                name: "IX_Udlejninger_UdlejningsScooterScooterId",
                table: "Udlejninger",
                newName: "IX_Udlejninger_UdlejningsScooterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Udlejninger_UdlejningsScootere_UdlejningsScooterId",
                table: "Udlejninger",
                column: "UdlejningsScooterId",
                principalTable: "UdlejningsScootere",
                principalColumn: "ScooterId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Udlejninger_UdlejningsScootere_UdlejningsScooterId",
                table: "Udlejninger");

            migrationBuilder.RenameColumn(
                name: "UdlejningsScooterId",
                table: "Udlejninger",
                newName: "UdlejningsScooterScooterId");

            migrationBuilder.RenameIndex(
                name: "IX_Udlejninger_UdlejningsScooterId",
                table: "Udlejninger",
                newName: "IX_Udlejninger_UdlejningsScooterScooterId");

            migrationBuilder.AddColumn<int>(
                name: "ScooterId",
                table: "Udlejninger",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Udlejninger_UdlejningsScootere_UdlejningsScooterScooterId",
                table: "Udlejninger",
                column: "UdlejningsScooterScooterId",
                principalTable: "UdlejningsScootere",
                principalColumn: "ScooterId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
