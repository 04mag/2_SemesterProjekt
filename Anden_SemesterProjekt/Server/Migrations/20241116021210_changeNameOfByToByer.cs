using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class changeNameOfByToByer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresser_By_ByPostnummer",
                table: "Adresser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_By",
                table: "By");

            migrationBuilder.RenameTable(
                name: "By",
                newName: "Byer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Byer",
                table: "Byer",
                column: "Postnummer");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresser_Byer_ByPostnummer",
                table: "Adresser",
                column: "ByPostnummer",
                principalTable: "Byer",
                principalColumn: "Postnummer",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresser_Byer_ByPostnummer",
                table: "Adresser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Byer",
                table: "Byer");

            migrationBuilder.RenameTable(
                name: "Byer",
                newName: "By");

            migrationBuilder.AddPrimaryKey(
                name: "PK_By",
                table: "By",
                column: "Postnummer");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresser_By_ByPostnummer",
                table: "Adresser",
                column: "ByPostnummer",
                principalTable: "By",
                principalColumn: "Postnummer",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
