using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateToUdlejningPropertyNavne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "selvrisiko",
                table: "Udlejninger",
                newName: "Selvrisiko");

            migrationBuilder.RenameColumn(
                name: "prisPrKm",
                table: "Udlejninger",
                newName: "PrisPrKm");

            migrationBuilder.RenameColumn(
                name: "lejePrDag",
                table: "Udlejninger",
                newName: "LejePrDag");

            migrationBuilder.RenameColumn(
                name: "forsikringPrDag",
                table: "Udlejninger",
                newName: "ForsikringPrDag");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Selvrisiko",
                table: "Udlejninger",
                newName: "selvrisiko");

            migrationBuilder.RenameColumn(
                name: "PrisPrKm",
                table: "Udlejninger",
                newName: "prisPrKm");

            migrationBuilder.RenameColumn(
                name: "LejePrDag",
                table: "Udlejninger",
                newName: "lejePrDag");

            migrationBuilder.RenameColumn(
                name: "ForsikringPrDag",
                table: "Udlejninger",
                newName: "forsikringPrDag");
        }
    }
}
