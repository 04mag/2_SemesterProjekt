using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class StaveFejlRettettIRegNR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scootere_Mærker_ScooterMærkeMærkeId",
                table: "Scootere");

            migrationBuilder.RenameColumn(
                name: "ScooterMærkeMærkeId",
                table: "Scootere",
                newName: "MærkeId");

            migrationBuilder.RenameIndex(
                name: "IX_Scootere_ScooterMærkeMærkeId",
                table: "Scootere",
                newName: "IX_Scootere_MærkeId");

            migrationBuilder.RenameColumn(
                name: "Mærke",
                table: "Mærker",
                newName: "ScooterMærke");

            migrationBuilder.AlterColumn<string>(
                name: "Stelnummer",
                table: "Scootere",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 1,
                column: "ScooterMærke",
                value: "Aprilla");

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 2,
                column: "ScooterMærke",
                value: "Derbi");

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 3,
                column: "ScooterMærke",
                value: "Karma");

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 4,
                column: "ScooterMærke",
                value: "Lindebjerg");

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 5,
                column: "ScooterMærke",
                value: "Pegasus");

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 6,
                column: "ScooterMærke",
                value: "Peugeot");

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 7,
                column: "ScooterMærke",
                value: "PGO");

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 8,
                column: "ScooterMærke",
                value: "Puch");

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 9,
                column: "ScooterMærke",
                value: "Vespa");

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 10,
                column: "ScooterMærke",
                value: "Yamaha");

            migrationBuilder.AddForeignKey(
                name: "FK_Scootere_Mærker_MærkeId",
                table: "Scootere",
                column: "MærkeId",
                principalTable: "Mærker",
                principalColumn: "MærkeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scootere_Mærker_MærkeId",
                table: "Scootere");

            migrationBuilder.RenameColumn(
                name: "MærkeId",
                table: "Scootere",
                newName: "ScooterMærkeMærkeId");

            migrationBuilder.RenameIndex(
                name: "IX_Scootere_MærkeId",
                table: "Scootere",
                newName: "IX_Scootere_ScooterMærkeMærkeId");

            migrationBuilder.RenameColumn(
                name: "ScooterMærke",
                table: "Mærker",
                newName: "Mærke");

            migrationBuilder.AlterColumn<string>(
                name: "Stelnummer",
                table: "Scootere",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 1,
                column: "Mærke",
                value: null);

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 2,
                column: "Mærke",
                value: null);

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 3,
                column: "Mærke",
                value: null);

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 4,
                column: "Mærke",
                value: null);

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 5,
                column: "Mærke",
                value: null);

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 6,
                column: "Mærke",
                value: null);

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 7,
                column: "Mærke",
                value: null);

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 8,
                column: "Mærke",
                value: null);

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 9,
                column: "Mærke",
                value: null);

            migrationBuilder.UpdateData(
                table: "Mærker",
                keyColumn: "MærkeId",
                keyValue: 10,
                column: "Mærke",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Scootere_Mærker_ScooterMærkeMærkeId",
                table: "Scootere",
                column: "ScooterMærkeMærkeId",
                principalTable: "Mærker",
                principalColumn: "MærkeId");
        }
    }
}
