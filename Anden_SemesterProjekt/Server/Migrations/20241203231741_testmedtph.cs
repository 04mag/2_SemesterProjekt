using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class testmedtph : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ydelser");

            migrationBuilder.AddColumn<double>(
                name: "AntalTimer",
                table: "Varer",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Varer",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "Rabat",
                table: "VareLinjer",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AntalTimer",
                table: "Varer");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Varer");

            migrationBuilder.AlterColumn<double>(
                name: "Rabat",
                table: "VareLinjer",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

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
        }
    }
}
