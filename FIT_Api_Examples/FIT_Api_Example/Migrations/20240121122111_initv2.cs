using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Example.Migrations
{
    public partial class initv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AkademskaGodina",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AkademskaGodina", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skracenica = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlikaKorisnika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlikaKorisnikaMala = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlikaKorisnikaVelika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsProdekan = table.Column<bool>(type: "bit", nullable: false),
                    IsDekan = table.Column<bool>(type: "bit", nullable: false),
                    IsStudentskaSluzba = table.Column<bool>(type: "bit", nullable: false),
                    Is2FActive = table.Column<bool>(type: "bit", nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Predmet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ects = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Opstina",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrzavaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opstina", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Opstina_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "AutentifikacijaToken",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrijednost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VrijemeEvidentiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAdresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is2FOtkljucano = table.Column<bool>(type: "bit", nullable: false),
                    KorisnickiNalogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutentifikacijaToken", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LogKretanjePoSistemu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    QueryPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAdresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsException = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogKretanjePoSistemu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LogKretanjePoSistemu_KorisnickiNalog_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Nastavnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nastavnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Nastavnik_KorisnickiNalog_ID",
                        column: x => x.ID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Obavijest",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByKorisnikID = table.Column<int>(type: "int", nullable: false),
                    IzmijenioKorisnikID = table.Column<int>(type: "int", nullable: false),
                    DatumUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Obavijest_KorisnickiNalog_CreatedByKorisnikID",
                        column: x => x.CreatedByKorisnikID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Obavijest_KorisnickiNalog_IzmijenioKorisnikID",
                        column: x => x.IzmijenioKorisnikID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Ispit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumVrijemeIspita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PredmetID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ispit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ispit_Predmet_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmet",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    BrojIndeksa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Obrisan = table.Column<bool>(type: "bit", nullable: false),
                    OpstinaRodjenjaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Student_KorisnickiNalog_ID",
                        column: x => x.ID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Student_Opstina_OpstinaRodjenjaID",
                        column: x => x.OpstinaRodjenjaID,
                        principalTable: "Opstina",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PrijavaIspita",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPrijave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OdjavaIspit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    IspitID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijavaIspita", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PrijavaIspita_Ispit_IspitID",
                        column: x => x.IspitID,
                        principalTable: "Ispit",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PrijavaIspita_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UpisAkGodine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvidentiraoKorisnikId = table.Column<int>(type: "int", nullable: false),
                    DatumUpisZimski = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Godinastudina = table.Column<int>(type: "int", nullable: false),
                    CijenaSkolarine = table.Column<float>(type: "real", nullable: false),
                    JelObnova = table.Column<bool>(type: "bit", nullable: false),
                    AkademskaGodinaId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    DatumOvjeraZimski = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpisAkGodine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpisAkGodine_AkademskaGodina_AkademskaGodinaId",
                        column: x => x.AkademskaGodinaId,
                        principalTable: "AkademskaGodina",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UpisAkGodine_KorisnickiNalog_EvidentiraoKorisnikId",
                        column: x => x.EvidentiraoKorisnikId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UpisAkGodine_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutentifikacijaToken_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Ispit_PredmetID",
                table: "Ispit",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_LogKretanjePoSistemu_KorisnikID",
                table: "LogKretanjePoSistemu",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_CreatedByKorisnikID",
                table: "Obavijest",
                column: "CreatedByKorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_IzmijenioKorisnikID",
                table: "Obavijest",
                column: "IzmijenioKorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Opstina_DrzavaID",
                table: "Opstina",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaIspita_IspitID",
                table: "PrijavaIspita",
                column: "IspitID");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaIspita_StudentID",
                table: "PrijavaIspita",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_OpstinaRodjenjaID",
                table: "Student",
                column: "OpstinaRodjenjaID");

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodine_AkademskaGodinaId",
                table: "UpisAkGodine",
                column: "AkademskaGodinaId");

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodine_EvidentiraoKorisnikId",
                table: "UpisAkGodine",
                column: "EvidentiraoKorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodine_StudentId",
                table: "UpisAkGodine",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutentifikacijaToken");

            migrationBuilder.DropTable(
                name: "LogKretanjePoSistemu");

            migrationBuilder.DropTable(
                name: "Nastavnik");

            migrationBuilder.DropTable(
                name: "Obavijest");

            migrationBuilder.DropTable(
                name: "PrijavaIspita");

            migrationBuilder.DropTable(
                name: "UpisAkGodine");

            migrationBuilder.DropTable(
                name: "Ispit");

            migrationBuilder.DropTable(
                name: "AkademskaGodina");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Predmet");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");

            migrationBuilder.DropTable(
                name: "Opstina");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
