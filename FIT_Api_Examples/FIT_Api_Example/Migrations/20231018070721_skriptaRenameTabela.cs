using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Example.Migrations
{
    public partial class skriptaRenameTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opstina_TblDrzava_DrzavaID",
                table: "Opstina");

            migrationBuilder.DropForeignKey(
                name: "FK_TblNastavnik_KorisnickiNalog_ID",
                table: "TblNastavnik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblNastavnik",
                table: "TblNastavnik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TblDrzava",
                table: "TblDrzava");

            migrationBuilder.RenameTable(
                name: "TblNastavnik",
                newName: "Nastavnik");

            migrationBuilder.RenameTable(
                name: "TblDrzava",
                newName: "Drzava");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nastavnik",
                table: "Nastavnik",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drzava",
                table: "Drzava",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Nastavnik_KorisnickiNalog_ID",
                table: "Nastavnik",
                column: "ID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Opstina_Drzava_DrzavaID",
                table: "Opstina",
                column: "DrzavaID",
                principalTable: "Drzava",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nastavnik_KorisnickiNalog_ID",
                table: "Nastavnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Opstina_Drzava_DrzavaID",
                table: "Opstina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nastavnik",
                table: "Nastavnik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drzava",
                table: "Drzava");

            migrationBuilder.RenameTable(
                name: "Nastavnik",
                newName: "TblNastavnik");

            migrationBuilder.RenameTable(
                name: "Drzava",
                newName: "TblDrzava");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblNastavnik",
                table: "TblNastavnik",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TblDrzava",
                table: "TblDrzava",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Opstina_TblDrzava_DrzavaID",
                table: "Opstina",
                column: "DrzavaID",
                principalTable: "TblDrzava",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblNastavnik_KorisnickiNalog_ID",
                table: "TblNastavnik",
                column: "ID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID");
        }
    }
}
