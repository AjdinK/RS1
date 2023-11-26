using System;
using System.Collections.Generic;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul0_Autentifikacija.ViewModels;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using FIT_Api_Examples.Modul5_OnlineTestovi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul1_TestniPodaci.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestniPodaciController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TestniPodaciController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult Count()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            data.Add("Nastavnik", _dbContext.Nastavnik.Count());
            data.Add("Student", _dbContext.Student.Count());
            data.Add("KorisnickiNalog", _dbContext.KorisnickiNalog.Count());
            data.Add("Opstina", _dbContext.Opstina.Count());
            data.Add("PrijavaIspita", _dbContext.PrijavaIspita.Count());
            data.Add("Predmet", _dbContext.Predmet.Count());
            data.Add("AkademskaGodina", _dbContext.AkademskaGodina.Count());
            data.Add("Drzava", _dbContext.Drzava.Count());
            data.Add("PredmetOblast", _dbContext.PredmetOblast.Count());

            return Ok(data);
        }

        [HttpPost]
        public ActionResult Generisi()
        {
            var drzave = new List<Drzava>();
            var opstine = new List<Opstina>();
            var predmeti = new List<Predmet>();
            var studenti = new List<Student>();
            var nastavnici = new List<Nastavnik>();
            var akademskeGodine = new List<AkademskaGodina>();

            var predmetOblast = new List<PredmetOblast>();
            var pitanja = new List<Pitanje>();
            var studentTest = new List<StudentTest>();
            var studentTestPitanja = new List<StudentTestPitanja>();
            var aktivacijaTesta = new List<AktivacijaTesta>();

            akademskeGodine.Add(new AkademskaGodina { opis = "2019-20" });
            akademskeGodine.Add(new AkademskaGodina { opis = "2020-21" });
            akademskeGodine.Add(new AkademskaGodina { opis = "2021-22" });
            akademskeGodine.Add(new AkademskaGodina { opis = "2022-23" });

            drzave.Add(new Drzava { Naziv = "BiH" , Skracenica = "BH" });
            drzave.Add(new Drzava { Naziv = "Njemacka" , Skracenica = "GER" });
            drzave.Add(new Drzava { Naziv = "Austrija" , Skracenica = "AUS" });
            drzave.Add(new Drzava { Naziv = "Turska" , Skracenica = "TUR" });
            drzave.Add(new Drzava { Naziv = "SAD" , Skracenica = "USA"  });
            drzave.Add(new Drzava { Naziv = "Malezija" , Skracenica = "MAL" });

            opstine.Add(new Opstina { Description = "Sarajevo", Drzava = drzave[0] });
            opstine.Add(new Opstina { Description = "Bihac", Drzava = drzave[0] });
            opstine.Add(new Opstina { Description = "Zenica", Drzava = drzave[0] });

            opstine.Add(new Opstina { Description = "Berlin", Drzava = drzave[1] });
            opstine.Add(new Opstina { Description = "Frankfurt", Drzava = drzave[1] });

            opstine.Add(new Opstina { Description = "Wien", Drzava = drzave[2] });
            opstine.Add(new Opstina { Description = "Wels", Drzava = drzave[2] });

            opstine.Add(new Opstina { Description = "Istanbul", Drzava = drzave[3] });
            opstine.Add(new Opstina { Description = "Bursa", Drzava = drzave[3] });

            opstine.Add(new Opstina { Description = "Boston", Drzava = drzave[4] });
            opstine.Add(new Opstina { Description = "New York", Drzava = drzave[4] });

            opstine.Add(new Opstina { Description = "Kuala Lumpur", Drzava = drzave[5] });
            opstine.Add(new Opstina { Description = "Subang Jaya", Drzava = drzave[5] });

            predmeti.Add(new Predmet { ECTS = 5, Naziv = "Programiranje III", Sifra = "RS-PR3" });
            predmeti.Add(new Predmet { ECTS = 5, Naziv = "Razvoj softvera I", Sifra = "RS-RS1" });
            predmeti.Add(new Predmet { ECTS = 5, Naziv = "Razvoj softvera II", Sifra = "RS-RS2" });

            nastavnici.Add(new Nastavnik { Ime = "Denis", Prezime = "Music", KorisnickoIme = "denis", Lozinka = "test", Email = "aaa@gmail.com", AktivacijaGUID = Guid.NewGuid().ToString() });
            nastavnici.Add(new Nastavnik { Ime = "Emina", Prezime = "Junuz", KorisnickoIme = "emina", Lozinka = "test", Email = "aaa@gmail.com", AktivacijaGUID = Guid.NewGuid().ToString() });
            nastavnici.Add(new Nastavnik { Ime = "Iris", Prezime = "Memic-Fisic", KorisnickoIme = "iris", Lozinka = "test", isProdekan = true, Email = "aaa@gmail.com", AktivacijaGUID = Guid.NewGuid().ToString() });
            nastavnici.Add(new Nastavnik { Ime = "Nina", Prezime = "Bijedic", KorisnickoIme = "nina", Lozinka = "test", isDekan = true, Email = "aaa@gmail.com", AktivacijaGUID = Guid.NewGuid().ToString() });
            nastavnici.Add(new Nastavnik { Ime = "Adil", Prezime = "Joldic", KorisnickoIme = "adil", Lozinka = "test", isAdmin = true, Email = "aaa@gmail.com", AktivacijaGUID = Guid.NewGuid().ToString() });
            nastavnici.Add(new Nastavnik { Ime = "Ajdin", Prezime = "Kuduzovic", KorisnickoIme = "test", Lozinka = "test", isAdmin = true, Email = "aaa@gmail.com", AktivacijaGUID = Guid.NewGuid().ToString(), isAktiviran = true,});


            Random rnd = new Random();

            for (int i = 0; i < 100; i++)
            {
                studenti.Add(new Student
                {
                    BrojIndeksa = $"IB200{i:d}",
                    CreatedTime = DateTime.Now,
                    Ime = TokenGenerator.GenerisiIme(5),
                    Prezime = TokenGenerator.GenerisiIme(5),
                    KorisnickoIme = TokenGenerator.GenerisiIme(5),
                    Lozinka = "test",
                    Opstina_Rodjenja = opstine.GetRandomElements(1)[0],
                    Email = "test@gmail.com",
                    AktivacijaGUID = Guid.NewGuid().ToString(),
                    isAktiviran = true,
                });
            }

            _dbContext.AddRange(nastavnici);
            _dbContext.AddRange(predmeti);
            _dbContext.AddRange(opstine);
            _dbContext.AddRange(drzave);
            _dbContext.AddRange(akademskeGodine);
            _dbContext.AddRange(studenti);
            _dbContext.SaveChanges();


            predmetOblast.Add(
               new PredmetOblast
               {
                   Predmet = predmeti[0],
                   Naziv = "Oblast 1"
               });

            predmetOblast.Add(
                new PredmetOblast
                {
                    Predmet = predmeti[0],
                    Naziv = "Oblast 2"
                });

            predmetOblast.Add(
                new PredmetOblast
                {
                    Predmet = predmeti[0],
                    Naziv = "Oblast 3"
                });

            predmetOblast.Add(
                new PredmetOblast
                {
                    Predmet = predmeti[1],
                    Naziv = "Oblast A"
                });

            predmetOblast.Add(
                new PredmetOblast
                {
                    Predmet = predmeti[1],
                    Naziv = "Oblast B"
                });

            predmetOblast.Add(
                new PredmetOblast
                {
                    Predmet = predmeti[1],
                    Naziv = "Oblast C"
                });

            _dbContext.AddRange(predmetOblast);


            pitanja.Add(new Pitanje
            {
                PredmetOblast = predmetOblast[0],
                BodoviPozitivni = 4,
                BodoviNegativni = 1,
                TekstPitanja = "Osnovna ideja korištenja slojeva u softverskoj arhitekturi je (odabrati tačne odgovore):",
                TipPitanja = TipPitanja.MCMA,
                ParcijalnoBodovanje = true,
                PitanjaPonudjeneOpcijes = new List<PitanjaPonudjeneOpcije>
                {
                    new PitanjaPonudjeneOpcije
                    {
                        JelTacno = true,
                        Opis = "Logički povezani elementi (klase, paketi...) se organizuju u pojedine slojeve sa jasno odvojenim zaduženjima tako da se niži slojevi brinu o generalnim servisima (npr. DB sloj), a viši slojevi se brinu o pitanjima poslovne logike."
                    },
                    new PitanjaPonudjeneOpcije
                    {
                        JelTacno = false,
                        Opis = "Logički povezani elementi (klase, paketi...) se organizuju u pojedine slojeve sa jasno odvojenim zaduženjima tako da se viši slojevi brinu o generalnim servisima (npr. DB sloj), a niži slojevi se brinu o pitanjima poslovne logike."
                    },
                    new PitanjaPonudjeneOpcije
                    {
                        JelTacno = true,
                        Opis = "Objekti iz viših slojeva šalju poruke objektima iz nižih slojeva (obrnuto se izbjegava)."
                    },
                    new PitanjaPonudjeneOpcije
                    {
                        JelTacno = false,
                        Opis = "Objekti iz nižih slojeva šalju poruke objektima iz viših slojeva (obrnuto se izbjegava)."
                    },
                    new PitanjaPonudjeneOpcije
                    {
                        JelTacno = false,
                        Opis = "Slojevita arhitektura nudi veće performanse u obradi podataka"
                    },
                }
            });

            pitanja.Add(new Pitanje
            {
                PredmetOblast = predmetOblast[0],
                BodoviPozitivni = 2,
                BodoviNegativni = 1,
                TekstPitanja = "Ako su EF migracije uključene u projektu, nije dozvoljeno mijenjati strukturu DB-a preko SQL alata",
                TipPitanja = TipPitanja.SCMA,
                ParcijalnoBodovanje = true,
                PitanjaPonudjeneOpcijes = new List<PitanjaPonudjeneOpcije>
                {
                    new PitanjaPonudjeneOpcije
                    {
                        JelTacno = true,
                        Opis = "Tacno"
                    },
                    new PitanjaPonudjeneOpcije
                    {
                        JelTacno = false,
                        Opis = "Netacno"
                    },

                }
            });

            _dbContext.AddRange(pitanja);
            
            aktivacijaTesta.Add(new AktivacijaTesta
            {
                Predmet = predmetOblast[0].Predmet,
                Naziv = "test 1",
                TrajanjeMinute = 10,
                Pocetak = new DateTime(2023, 01, 10),
                Kraj = new DateTime(2023, 02, 10),
            });

            aktivacijaTesta.Add(new AktivacijaTesta
            {
                Predmet = predmetOblast[0].Predmet,
                Naziv = "test 2",
                TrajanjeMinute = 15,
                Pocetak = new DateTime(2023, 01, 11),
                Kraj = new DateTime(2023, 02, 13),
            });
            _dbContext.AddRange(aktivacijaTesta);


            studentTest.Add(new StudentTest()
            {
                Student = studenti[0],
                AktivacijaTesta = aktivacijaTesta[0],
                TestPokrenutVrijeme = DateTime.Now,
            });

            studentTest.Add(new StudentTest()
            {
                Student = studenti[0],
                AktivacijaTesta = aktivacijaTesta[0],
                TestPokrenutVrijeme = DateTime.Now.AddDays(-1),
            });

            _dbContext.AddRange(studentTest);

            studentTestPitanja.Add(new StudentTestPitanja
            {
                StudentTest = studentTest[0],
                MaxBodovi = pitanja[0].BodoviPozitivni,
                OstvareniBodovi = 0,
                Pitanje = pitanja[0],
                OznaceniOdgovoriIDs = new List<int> { 13, 34 },
            });

            studentTestPitanja.Add(new StudentTestPitanja
            {
                StudentTest = studentTest[0],
                MaxBodovi = pitanja[1].BodoviPozitivni,
                OstvareniBodovi = 0,
                Pitanje = pitanja[1],
                OznaceniOdgovoriIDs = new List<int> { 10 },
            });

            studentTestPitanja.Add(new StudentTestPitanja
            {
                StudentTest = studentTest[1],
                MaxBodovi = pitanja[0].BodoviPozitivni,
                OstvareniBodovi = 0,
                Pitanje = pitanja[0],
                OznaceniOdgovoriIDs = new List<int> { 13, 34 },
            });

            studentTestPitanja.Add(new StudentTestPitanja
            {
                StudentTest = studentTest[1],
                MaxBodovi = pitanja[1].BodoviPozitivni,
                OstvareniBodovi = 0,
                Pitanje = pitanja[1],
                OznaceniOdgovoriIDs = new List<int> { 10 },
            });

            _dbContext.AddRange(studentTestPitanja);
            _dbContext.SaveChanges();
            return Count();
        }
    }
}