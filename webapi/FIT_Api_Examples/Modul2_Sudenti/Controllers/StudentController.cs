using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul2.ViewModels;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [Autorizacija(true, true, true, false, true)]
        [HttpPost("{id}")]

        public ActionResult Obrisi2(int id)
        {
            Student student = _dbContext.Student.Find(id);

            if (student == null || id == 1)
                return BadRequest("pogresan ID");

            _dbContext.Remove(student);
            _dbContext.SaveChanges();
            return Ok(student);
        }

        [Autorizacija(true, true, true, false, true)]
        [HttpPost]
        public ActionResult Snimi([FromBody] StudentGetAllVM x)
        {
            Student? student;
            if (x.id == 0)
            {
                student = new Student
                {
                    Created_Time = DateTime.Now,
                };

                _dbContext.Add(student);
            }
            else
            {
                student = _dbContext.Student.FirstOrDefault(s => s.Id == x.id);
            }

            if (student == null)
                return BadRequest("pogresan ID");

            student.Ime = x.ime.RemoveTags();
            student.Prezime = x.prezime.RemoveTags();
            student.Opstina_Rodjenja_Id = x.opstina_rodjenja_id;

            if (!string.IsNullOrEmpty(x.slika_korisnika_nova_base64))
            {
                //slika se snima u db
                byte[]? slika_bajtovi = x.slika_korisnika_nova_base64?.ParsirajBase64();

                if (slika_bajtovi == null)
                    return BadRequest("format slike nije base64");

                byte[]? slika_bajtovi_resized_velika = SlikeHelper.ResizeSlike(slika_bajtovi, 200, 75);
                byte[]? slika_bajtovi_resized_mala = SlikeHelper.ResizeSlike(slika_bajtovi, 50, 75);
                student.slika_korisnika_bajtovi = slika_bajtovi_resized_velika;

                //slika se snima na File System
                if (slika_bajtovi_resized_velika != null)
                    Fajlovi.Snimi(slika_bajtovi_resized_velika, "slike_korisnika/velika-" + student.Id + ".png");

                if (slika_bajtovi_resized_mala != null)
                    Fajlovi.Snimi(slika_bajtovi_resized_mala, "slike_korisnika/mala-" + student.Id + ".png");
            }

            if (x.omiljeni_predmeti?.Length > 0)
            {
                foreach (int pID in x.omiljeni_predmeti)
                {
                    var op = new OmiljeniPredmeti
                    {
                        PredmetId = pID,
                        Student = student
                    };
                    _dbContext.Add(op);
                }
            }

            _dbContext.SaveChanges();

            if (student.Broj_Indeksa != "")
            {
                student.Broj_Indeksa = "IB" + x.id;
                student.KorisnickoIme = x.broj_indeksa;
                student.Lozinka = TokenGenerator.Generate(5);
                _dbContext.SaveChanges();
            }
            return Ok();
        }

        //[Autorizacija(true, true, true, false, true)]
        [HttpGet]
        public ActionResult GetAll(string? ime_prezime , int pageNumber = 1 , int pageSize = 20)
        {
            var data = _dbContext.Student
                .Include(s => s.Opstina_Rodjenja.drzava)
                .Where(x => ime_prezime == null || (x.Ime + " " + x.Prezime).StartsWith(ime_prezime) || (x.Prezime + " " + x.Ime).StartsWith(ime_prezime))
                .OrderByDescending(s => s.Id)
                .Select(s => new StudentGetAllVM()
                {
                    id = s.Id,
                    ime = s.Ime,
                    prezime = s.Prezime,
                    broj_indeksa = s.Broj_Indeksa,
                    opstina_rodjenja_opis = s.Opstina_Rodjenja.description,
                    drzava_rodjenja_opis = s.Opstina_Rodjenja.drzava.Naziv,
                    opstina_rodjenja_id = s.Opstina_Rodjenja_Id,
                    vrijeme_dodavanja = s.Created_Time.ToString("dd.MM.yyyy"),
                    slika_korisnika_postojeca_base64_DB = s.slika_korisnika_bajtovi,//varijanta 1: slika iz DB
                });

                return Ok(PagedList<StudentGetAllVM>.Create(data,pageNumber,pageSize));

            // data.ForEach(s=>
            // {
            //     //varijanta 2: slika sa File systema
            //     s.slika_korisnika_postojeca_base64_FS = Fajlovi.Ucitaj("slike_korisnika/" + s.id + ".png")
            //                                             ?? Fajlovi.Ucitaj("wwwroot/profile_images/empty.png");//ako je null

            //     s.slika_korisnika_postojeca_base64_DB ??= Fajlovi.Ucitaj("wwwroot/profile_images/empty.png");//ako je null
            // });
            
        }

        [HttpGet("{id}")]
        public ActionResult GetSlikaDB(int id)
        {
            byte[]? bajtovi_slike = _dbContext.Student.Find(id).slika_korisnika_bajtovi
                                   ?? Fajlovi.Ucitaj("wwwroot/profile_images/empty.png");
            if (bajtovi_slike == null)
                throw new Exception();//bug

            return File(bajtovi_slike, "image/png");
        }

        [HttpGet("{id}")]
        public ActionResult GetSlikaFS(int id)
        {
            byte[]? bajtovi_slike = Fajlovi.Ucitaj("slike_korisnika/mala-" + id + ".png")
                                   ?? Fajlovi.Ucitaj("wwwroot/profile_images/empty.png");

            if (bajtovi_slike == null)
                throw new Exception();//bug

            return File(bajtovi_slike, "image/png");
        }
    }
}
