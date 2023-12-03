using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Example.Migrations
{
    public partial class initv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Ispit_Predmet_PredmetID",
                table: "Ispit");

            migrationBuilder.DropForeignKey(
                name: "FK_Obavijest_KorisnickiNalog_CreatedByKorisnikID",
                table: "Obavijest");

            migrationBuilder.DropForeignKey(
                name: "FK_Obavijest_KorisnickiNalog_IzmijenioKorisnikID",
                table: "Obavijest");

            migrationBuilder.DropForeignKey(
                name: "FK_Opstina_Drzava_DrzavaID",
                table: "Opstina");

            migrationBuilder.DropForeignKey(
                name: "FK_PrijavaIspita_Ispit_IspitID",
                table: "PrijavaIspita");

            migrationBuilder.DropForeignKey(
                name: "FK_PrijavaIspita_Student_StudentID",
                table: "PrijavaIspita");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Opstina_OpstinaRodjenjaID",
                table: "Student");

            migrationBuilder.AddForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ispit_Predmet_PredmetID",
                table: "Ispit",
                column: "PredmetID",
                principalTable: "Predmet",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Obavijest_KorisnickiNalog_CreatedByKorisnikID",
                table: "Obavijest",
                column: "CreatedByKorisnikID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Obavijest_KorisnickiNalog_IzmijenioKorisnikID",
                table: "Obavijest",
                column: "IzmijenioKorisnikID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Opstina_Drzava_DrzavaID",
                table: "Opstina",
                column: "DrzavaID",
                principalTable: "Drzava",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PrijavaIspita_Ispit_IspitID",
                table: "PrijavaIspita",
                column: "IspitID",
                principalTable: "Ispit",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PrijavaIspita_Student_StudentID",
                table: "PrijavaIspita",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Opstina_OpstinaRodjenjaID",
                table: "Student",
                column: "OpstinaRodjenjaID",
                principalTable: "Opstina",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Ispit_Predmet_PredmetID",
                table: "Ispit");

            migrationBuilder.DropForeignKey(
                name: "FK_Obavijest_KorisnickiNalog_CreatedByKorisnikID",
                table: "Obavijest");

            migrationBuilder.DropForeignKey(
                name: "FK_Obavijest_KorisnickiNalog_IzmijenioKorisnikID",
                table: "Obavijest");

            migrationBuilder.DropForeignKey(
                name: "FK_Opstina_Drzava_DrzavaID",
                table: "Opstina");

            migrationBuilder.DropForeignKey(
                name: "FK_PrijavaIspita_Ispit_IspitID",
                table: "PrijavaIspita");

            migrationBuilder.DropForeignKey(
                name: "FK_PrijavaIspita_Student_StudentID",
                table: "PrijavaIspita");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Opstina_OpstinaRodjenjaID",
                table: "Student");

            migrationBuilder.AddForeignKey(
                name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ispit_Predmet_PredmetID",
                table: "Ispit",
                column: "PredmetID",
                principalTable: "Predmet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Obavijest_KorisnickiNalog_CreatedByKorisnikID",
                table: "Obavijest",
                column: "CreatedByKorisnikID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Obavijest_KorisnickiNalog_IzmijenioKorisnikID",
                table: "Obavijest",
                column: "IzmijenioKorisnikID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Opstina_Drzava_DrzavaID",
                table: "Opstina",
                column: "DrzavaID",
                principalTable: "Drzava",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrijavaIspita_Ispit_IspitID",
                table: "PrijavaIspita",
                column: "IspitID",
                principalTable: "Ispit",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrijavaIspita_Student_StudentID",
                table: "PrijavaIspita",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Opstina_OpstinaRodjenjaID",
                table: "Student",
                column: "OpstinaRodjenjaID",
                principalTable: "Opstina",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
