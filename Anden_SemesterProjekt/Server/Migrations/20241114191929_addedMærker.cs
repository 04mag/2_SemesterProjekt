using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class addedMærker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MekanikerMærke_Mærke_MærkerMærkeId",
                table: "MekanikerMærke");

            migrationBuilder.DropForeignKey(
                name: "FK_Scootere_Mærke_MærkeId",
                table: "Scootere");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mærke",
                table: "ScooterMærke");

            migrationBuilder.RenameTable(
                name: "ScooterMærke",
                newName: "Mærker");

            migrationBuilder.AlterColumn<string>(
                name: "Navn",
                table: "Mekanikere",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mærker",
                table: "Mærker",
                column: "MærkeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MekanikerMærke_Mærker_MærkerMærkeId",
                table: "MekanikerMærke",
                column: "MærkerMærkeId",
                principalTable: "Mærker",
                principalColumn: "MærkeId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_MekanikerMærke_Mærker_MærkerMærkeId",
                table: "MekanikerMærke");

            migrationBuilder.DropForeignKey(
                name: "FK_Scootere_Mærker_MærkeId",
                table: "Scootere");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mærker",
                table: "Mærker");

            migrationBuilder.RenameTable(
                name: "Mærker",
                newName: "ScooterMærke");

            migrationBuilder.AlterColumn<string>(
                name: "Navn",
                table: "Mekanikere",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mærke",
                table: "ScooterMærke",
                column: "MærkeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MekanikerMærke_Mærke_MærkerMærkeId",
                table: "MekanikerMærke",
                column: "MærkerMærkeId",
                principalTable: "ScooterMærke",
                principalColumn: "MærkeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scootere_Mærke_MærkeId",
                table: "Scootere",
                column: "MærkeId",
                principalTable: "ScooterMærke",
                principalColumn: "MærkeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
