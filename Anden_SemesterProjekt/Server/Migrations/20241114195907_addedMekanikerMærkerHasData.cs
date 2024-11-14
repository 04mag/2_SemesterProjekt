using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class addedMekanikerMærkerHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MekanikerMærke_Mekanikere_MekanikereMekanikerId",
                table: "MekanikerMærke");

            migrationBuilder.DropForeignKey(
                name: "FK_MekanikerMærke_Mærker_MærkerMærkeId",
                table: "MekanikerMærke");

            migrationBuilder.RenameColumn(
                name: "MærkerMærkeId",
                table: "MekanikerMærke",
                newName: "MærkeId");

            migrationBuilder.RenameColumn(
                name: "MekanikereMekanikerId",
                table: "MekanikerMærke",
                newName: "MekanikerId");

            migrationBuilder.RenameIndex(
                name: "IX_MekanikerMærke_MærkerMærkeId",
                table: "MekanikerMærke",
                newName: "IX_MekanikerMærke_MærkeId");

            migrationBuilder.InsertData(
                table: "MekanikerMærke",
                columns: new[] { "MekanikerId", "MærkeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 8 },
                    { 1, 10 },
                    { 2, 3 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 10 },
                    { 3, 2 },
                    { 3, 8 },
                    { 3, 9 },
                    { 3, 10 },
                    { 4, 1 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 7 },
                    { 4, 9 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MekanikerMærke_Mekanikere_MekanikerId",
                table: "MekanikerMærke",
                column: "MekanikerId",
                principalTable: "Mekanikere",
                principalColumn: "MekanikerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MekanikerMærke_Mærker_MærkeId",
                table: "MekanikerMærke",
                column: "MærkeId",
                principalTable: "Mærker",
                principalColumn: "MærkeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MekanikerMærke_Mekanikere_MekanikerId",
                table: "MekanikerMærke");

            migrationBuilder.DropForeignKey(
                name: "FK_MekanikerMærke_Mærker_MærkeId",
                table: "MekanikerMærke");

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 4, 7 });

            migrationBuilder.DeleteData(
                table: "MekanikerMærke",
                keyColumns: new[] { "MekanikerId", "MærkeId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.RenameColumn(
                name: "MærkeId",
                table: "MekanikerMærke",
                newName: "MærkerMærkeId");

            migrationBuilder.RenameColumn(
                name: "MekanikerId",
                table: "MekanikerMærke",
                newName: "MekanikereMekanikerId");

            migrationBuilder.RenameIndex(
                name: "IX_MekanikerMærke_MærkeId",
                table: "MekanikerMærke",
                newName: "IX_MekanikerMærke_MærkerMærkeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MekanikerMærke_Mekanikere_MekanikereMekanikerId",
                table: "MekanikerMærke",
                column: "MekanikereMekanikerId",
                principalTable: "Mekanikere",
                principalColumn: "MekanikerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MekanikerMærke_Mærker_MærkerMærkeId",
                table: "MekanikerMærke",
                column: "MærkerMærkeId",
                principalTable: "Mærker",
                principalColumn: "MærkeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
