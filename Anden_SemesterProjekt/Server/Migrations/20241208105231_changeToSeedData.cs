﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anden_SemesterProjekt.Server.Migrations
{
    /// <inheritdoc />
    public partial class changeToSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ordrer",
                keyColumn: "OrdreId",
                keyValue: 2,
                columns: new[] { "SlutDato", "StartDato" },
                values: new object[] { new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Ordrer",
                keyColumn: "OrdreId",
                keyValue: 3,
                columns: new[] { "SlutDato", "StartDato" },
                values: new object[] { new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Udlejninger",
                keyColumn: "UdlejningId",
                keyValue: 2,
                columns: new[] { "SlutDato", "StartDato" },
                values: new object[] { new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ordrer",
                keyColumn: "OrdreId",
                keyValue: 2,
                columns: new[] { "SlutDato", "StartDato" },
                values: new object[] { new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Ordrer",
                keyColumn: "OrdreId",
                keyValue: 3,
                columns: new[] { "SlutDato", "StartDato" },
                values: new object[] { new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Udlejninger",
                keyColumn: "UdlejningId",
                keyValue: 2,
                columns: new[] { "SlutDato", "StartDato" },
                values: new object[] { new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}