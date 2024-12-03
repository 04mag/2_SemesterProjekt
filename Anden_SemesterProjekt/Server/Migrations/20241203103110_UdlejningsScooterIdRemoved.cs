using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class UdlejningsScooterIdRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scootere_Mærker_MærkeId",
                table: "Scootere");

            migrationBuilder.DropColumn(
                name: "UdlejningId",
                table: "Ordrer");

            migrationBuilder.AddForeignKey(
                name: "FK_Scootere_Mærker_MærkeId",
                table: "Scootere",
                column: "MærkeId",
                principalTable: "Mærker",
                principalColumn: "MærkeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scootere_Mærker_MærkeId",
                table: "Scootere");

            migrationBuilder.AddColumn<int>(
                name: "UdlejningId",
                table: "Ordrer",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Scootere_Mærker_MærkeId",
                table: "Scootere",
                column: "MærkeId",
                principalTable: "Mærker",
                principalColumn: "MærkeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
