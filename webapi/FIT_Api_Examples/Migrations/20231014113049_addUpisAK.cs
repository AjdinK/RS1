using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Examples.Migrations
{
    /// <inheritdoc />
    public partial class addUpisAK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumUpisZimski",
                table: "UpisAkGodine",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumOvjeraZimski",
                table: "UpisAkGodine",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EvidentiraoKorisnikID",
                table: "UpisAkGodine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodine_EvidentiraoKorisnikID",
                table: "UpisAkGodine",
                column: "EvidentiraoKorisnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_UpisAkGodine_KorisnickiNalog_EvidentiraoKorisnikID",
                table: "UpisAkGodine",
                column: "EvidentiraoKorisnikID",
                principalTable: "KorisnickiNalog",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpisAkGodine_KorisnickiNalog_EvidentiraoKorisnikID",
                table: "UpisAkGodine");

            migrationBuilder.DropIndex(
                name: "IX_UpisAkGodine_EvidentiraoKorisnikID",
                table: "UpisAkGodine");

            migrationBuilder.DropColumn(
                name: "DatumOvjeraZimski",
                table: "UpisAkGodine");

            migrationBuilder.DropColumn(
                name: "EvidentiraoKorisnikID",
                table: "UpisAkGodine");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatumUpisZimski",
                table: "UpisAkGodine",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
