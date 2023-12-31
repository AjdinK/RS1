﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Examples.Migrations
{
    /// <inheritdoc />
    public partial class initv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skracenica = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    slika_korisnika_bajtovi = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    isAdmin = table.Column<bool>(type: "bit", nullable: false),
                    isProdekan = table.Column<bool>(type: "bit", nullable: false),
                    isDekan = table.Column<bool>(type: "bit", nullable: false),
                    isStudentskaSluzba = table.Column<bool>(type: "bit", nullable: false),
                    isAktiviran = table.Column<bool>(type: "bit", nullable: false),
                    AktivacijaGUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Predmet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ECTS = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Opstina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrzavaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opstina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opstina_Drzava_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzava",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AkademskaGodina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    evidentiraoKorisnikId = table.Column<int>(type: "int", nullable: true),
                    izmijenioKorisnikId = table.Column<int>(type: "int", nullable: true),
                    datum_update = table.Column<DateTime>(type: "datetime2", nullable: true),
                    datum_added = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AkademskaGodina", x => x.id);
                    table.ForeignKey(
                        name: "FK_AkademskaGodina_KorisnickiNalog_evidentiraoKorisnikId",
                        column: x => x.evidentiraoKorisnikId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AkademskaGodina_KorisnickiNalog_izmijenioKorisnikId",
                        column: x => x.izmijenioKorisnikId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AutentifikacijaToken",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vrijednost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickiNalogId = table.Column<int>(type: "int", nullable: false),
                    vrijemeEvidentiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ipAdresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    twoFactorCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    twoFactorCodeJelAktiviran = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutentifikacijaToken", x => x.id);
                    table.ForeignKey(
                        name: "FK_AutentifikacijaToken_KorisnickiNalog_KorisnickiNalogId",
                        column: x => x.KorisnickiNalogId,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LogKretanjePoSistemu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    queryPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    postData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vrijeme = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ipAdresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    exceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isException = table.Column<bool>(type: "bit", nullable: false),
                    korisnikID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogKretanjePoSistemu", x => x.id);
                    table.ForeignKey(
                        name: "FK_LogKretanjePoSistemu_KorisnickiNalog_korisnikID",
                        column: x => x.korisnikID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Nastavnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nastavnik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nastavnik_KorisnickiNalog_Id",
                        column: x => x.Id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obavijest",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naslov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datum_kreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    evidentiraoKorisnikID = table.Column<int>(type: "int", nullable: false),
                    izmijenioKorisnikID = table.Column<int>(type: "int", nullable: false),
                    datum_update = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijest", x => x.id);
                    table.ForeignKey(
                        name: "FK_Obavijest_KorisnickiNalog_evidentiraoKorisnikID",
                        column: x => x.evidentiraoKorisnikID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Obavijest_KorisnickiNalog_izmijenioKorisnikID",
                        column: x => x.izmijenioKorisnikID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AktivacijaTesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrajanjeMinute = table.Column<float>(type: "real", nullable: false),
                    Pocetak = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kraj = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PredmetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AktivacijaTesta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AktivacijaTesta_Predmet_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmet",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Ispit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumIspita = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "PredmetOblast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PredmetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredmetOblast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PredmetOblast_Predmet_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmet",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BrojIndeksa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opstina_Rodjenja_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_KorisnickiNalog_Id",
                        column: x => x.Id,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Opstina_Opstina_Rodjenja_Id",
                        column: x => x.Opstina_Rodjenja_Id,
                        principalTable: "Opstina",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pitanje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TekstPitanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodoviPozitivni = table.Column<int>(type: "int", nullable: false),
                    BodoviNegativni = table.Column<int>(type: "int", nullable: false),
                    ParcijalnoBodovanje = table.Column<bool>(type: "bit", nullable: false),
                    TipPitanja = table.Column<int>(type: "int", nullable: false),
                    PredmetOblastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitanje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pitanje_PredmetOblast_PredmetOblastId",
                        column: x => x.PredmetOblastId,
                        principalTable: "PredmetOblast",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OmiljeniPredmeti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    PredmetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OmiljeniPredmeti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OmiljeniPredmeti_Predmet_PredmetId",
                        column: x => x.PredmetId,
                        principalTable: "Predmet",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_OmiljeniPredmeti_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PrijavaIspita",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPrijave = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentTest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestPokrenutVrijeme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TestZavrsenoVrijeme = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Uspjeh = table.Column<float>(type: "real", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    AktivacijaTestaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTest_AktivacijaTesta_AktivacijaTestaId",
                        column: x => x.AktivacijaTestaId,
                        principalTable: "AktivacijaTesta",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentTest_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UpisAkGodine",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    datumUpisZimski = table.Column<DateTime>(type: "datetime2", nullable: false),
                    godinastudina = table.Column<int>(type: "int", nullable: false),
                    cijenaSkolarine = table.Column<float>(type: "real", nullable: false),
                    jelObnova = table.Column<bool>(type: "bit", nullable: false),
                    datumOvjeraZimski = table.Column<DateTime>(type: "datetime2", nullable: true),
                    akademskaGodina_id = table.Column<int>(type: "int", nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: false),
                    evidentiraoKorisnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpisAkGodine", x => x.id);
                    table.ForeignKey(
                        name: "FK_UpisAkGodine_AkademskaGodina_akademskaGodina_id",
                        column: x => x.akademskaGodina_id,
                        principalTable: "AkademskaGodina",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UpisAkGodine_KorisnickiNalog_evidentiraoKorisnikID",
                        column: x => x.evidentiraoKorisnikID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UpisAkGodine_Student_student_id",
                        column: x => x.student_id,
                        principalTable: "Student",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PitanjaPonudjeneOpcije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JelTacno = table.Column<bool>(type: "bit", nullable: false),
                    PitanjaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PitanjaPonudjeneOpcije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PitanjaPonudjeneOpcije_Pitanje_PitanjaId",
                        column: x => x.PitanjaId,
                        principalTable: "Pitanje",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentTestPitanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaxBodovi = table.Column<float>(type: "real", nullable: false),
                    OstvareniBodovi = table.Column<float>(type: "real", nullable: false),
                    StudentTestId = table.Column<int>(type: "int", nullable: false),
                    PitanjeId = table.Column<int>(type: "int", nullable: false),
                    OznaceniOdgovoriIDsString = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTestPitanja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTestPitanja_Pitanje_PitanjeId",
                        column: x => x.PitanjeId,
                        principalTable: "Pitanje",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentTestPitanja_StudentTest_StudentTestId",
                        column: x => x.StudentTestId,
                        principalTable: "StudentTest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AkademskaGodina_evidentiraoKorisnikId",
                table: "AkademskaGodina",
                column: "evidentiraoKorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_AkademskaGodina_izmijenioKorisnikId",
                table: "AkademskaGodina",
                column: "izmijenioKorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_AktivacijaTesta_PredmetId",
                table: "AktivacijaTesta",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_AutentifikacijaToken_KorisnickiNalogId",
                table: "AutentifikacijaToken",
                column: "KorisnickiNalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Ispit_PredmetID",
                table: "Ispit",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_LogKretanjePoSistemu_korisnikID",
                table: "LogKretanjePoSistemu",
                column: "korisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_evidentiraoKorisnikID",
                table: "Obavijest",
                column: "evidentiraoKorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_izmijenioKorisnikID",
                table: "Obavijest",
                column: "izmijenioKorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_OmiljeniPredmeti_PredmetId",
                table: "OmiljeniPredmeti",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_OmiljeniPredmeti_StudentId",
                table: "OmiljeniPredmeti",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Opstina_DrzavaId",
                table: "Opstina",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_PitanjaPonudjeneOpcije_PitanjaId",
                table: "PitanjaPonudjeneOpcije",
                column: "PitanjaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pitanje_PredmetOblastId",
                table: "Pitanje",
                column: "PredmetOblastId");

            migrationBuilder.CreateIndex(
                name: "IX_PredmetOblast_PredmetId",
                table: "PredmetOblast",
                column: "PredmetId");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaIspita_IspitID",
                table: "PrijavaIspita",
                column: "IspitID");

            migrationBuilder.CreateIndex(
                name: "IX_PrijavaIspita_StudentID",
                table: "PrijavaIspita",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Opstina_Rodjenja_Id",
                table: "Student",
                column: "Opstina_Rodjenja_Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTest_AktivacijaTestaId",
                table: "StudentTest",
                column: "AktivacijaTestaId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTest_StudentId",
                table: "StudentTest",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTestPitanja_PitanjeId",
                table: "StudentTestPitanja",
                column: "PitanjeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTestPitanja_StudentTestId",
                table: "StudentTestPitanja",
                column: "StudentTestId");

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodine_akademskaGodina_id",
                table: "UpisAkGodine",
                column: "akademskaGodina_id");

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodine_evidentiraoKorisnikID",
                table: "UpisAkGodine",
                column: "evidentiraoKorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_UpisAkGodine_student_id",
                table: "UpisAkGodine",
                column: "student_id");
        }

        /// <inheritdoc />
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
                name: "OmiljeniPredmeti");

            migrationBuilder.DropTable(
                name: "PitanjaPonudjeneOpcije");

            migrationBuilder.DropTable(
                name: "PrijavaIspita");

            migrationBuilder.DropTable(
                name: "StudentTestPitanja");

            migrationBuilder.DropTable(
                name: "UpisAkGodine");

            migrationBuilder.DropTable(
                name: "Ispit");

            migrationBuilder.DropTable(
                name: "Pitanje");

            migrationBuilder.DropTable(
                name: "StudentTest");

            migrationBuilder.DropTable(
                name: "AkademskaGodina");

            migrationBuilder.DropTable(
                name: "PredmetOblast");

            migrationBuilder.DropTable(
                name: "AktivacijaTesta");

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
