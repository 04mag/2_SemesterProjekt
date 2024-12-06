using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class changeToKundeSeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 11,
                columns: new[] { "Email", "Navn" },
                values: new object[] { "JensNielsen@mail.dk", "Jens Nielsen" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Kunder",
                keyColumn: "KundeId",
                keyValue: 11,
                columns: new[] { "Email", "Navn" },
                values: new object[] { "TrNi@mail.dk", "Troels Nielsen" });
        }
    }
}
