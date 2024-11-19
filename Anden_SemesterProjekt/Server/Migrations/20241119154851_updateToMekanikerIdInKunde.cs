using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class updateToMekanikerIdInKunde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kunder_Mekanikere_MekanikerId",
                table: "Kunder");

            migrationBuilder.AlterColumn<int>(
                name: "MekanikerId",
                table: "Kunder",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Kunder_Mekanikere_MekanikerId",
                table: "Kunder",
                column: "MekanikerId",
                principalTable: "Mekanikere",
                principalColumn: "MekanikerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kunder_Mekanikere_MekanikerId",
                table: "Kunder");

            migrationBuilder.AlterColumn<int>(
                name: "MekanikerId",
                table: "Kunder",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kunder_Mekanikere_MekanikerId",
                table: "Kunder",
                column: "MekanikerId",
                principalTable: "Mekanikere",
                principalColumn: "MekanikerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
