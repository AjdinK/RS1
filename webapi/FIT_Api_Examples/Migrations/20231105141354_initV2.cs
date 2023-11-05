using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Examples.Migrations
{
    /// <inheritdoc />
    public partial class initV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AkademskaGodina_KorisnickiNalog_izmijenioKorisnikid",
                table: "AkademskaGodina");

            migrationBuilder.AlterColumn<int>(
                name: "izmijenioKorisnikid",
                table: "AkademskaGodina",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AkademskaGodina_KorisnickiNalog_izmijenioKorisnikid",
                table: "AkademskaGodina",
                column: "izmijenioKorisnikid",
                principalTable: "KorisnickiNalog",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AkademskaGodina_KorisnickiNalog_izmijenioKorisnikid",
                table: "AkademskaGodina");

            migrationBuilder.AlterColumn<int>(
                name: "izmijenioKorisnikid",
                table: "AkademskaGodina",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AkademskaGodina_KorisnickiNalog_izmijenioKorisnikid",
                table: "AkademskaGodina",
                column: "izmijenioKorisnikid",
                principalTable: "KorisnickiNalog",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
