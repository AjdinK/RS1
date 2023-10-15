using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        [HttpPost]
        public ActionResult<Student> Snimi([FromBody] StudentGetAllVM x)
        {
            //if (!HttpContext.GetLoginInfo().isLogiran)
            //    return BadRequest("nije logiran");

            Student? obj;

            if (x.id == 0)
            {
                obj = new Student() {
                    created_time = DateTime.Now,
                    slika_korisnika = Config.SlikeURL + "empty.png",
                };

                _dbContext.Add(obj);   
            }
            else {
                obj = _dbContext.Student.Include("opstina_rodjenja").FirstOrDefault
                    (s => s.id == x.id);

                if (obj == null) 
                    return BadRequest("Pogresen ID");
            }

            if (obj.broj_indeksa == null){
                obj.broj_indeksa = "IB" + x.id;
                obj.korisnickoIme = obj.ime + "_" + obj.prezime;
                obj.lozinka = TokenGenerator.Generate(8);
                _dbContext.SaveChanges();
            }

            obj.ime = x.ime.RemoveTags();
            obj.prezime = x.prezime.RemoveTags();
            obj.opstina_rodjenja_id = x.opstina_rodjenja_id;
            
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult<Student> BrisiByID (int id) {
            var obj = _dbContext.Student.Find(id);

            if (obj == null || id == 1) 
            return BadRequest("Pogresen ID");

            _dbContext.Student.Remove(obj);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public ActionResult<Student> BrisiByObj([FromBody] Student x)
        {
            var obj = _dbContext.Student.Find(x.id);

            if (obj == null || x.id == 1) 
            return BadRequest("Pogresen ID");

            _dbContext.Student.Remove(obj);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Student>> GetAll(string? ime_prezime)
        {
            var data = _dbContext.Student
                .Include(s => s.opstina_rodjenja.drzava)
                .Where(x => ime_prezime == null || (x.ime + " " + x.prezime).StartsWith(ime_prezime) || (x.prezime + " " + x.ime).StartsWith(ime_prezime))
                .OrderByDescending(s => s.id)
                .Take(100)
                .Select(s=> new StudentGetAllVM {
                    id = s.id,
                    ime = s.ime,
                    prezime = s.prezime,
                    broj_indeksa = s.broj_indeksa,
                    opstina_rodjenja_opis = s.opstina_rodjenja.description,
                    opstina_rodjenja_id = s.opstina_rodjenja_id,
                    drzava_rodjeja_opis = s.opstina_rodjenja.drzava.naziv,
                    vrijeme_dodavanje = s.created_time.ToString("dd.MM.yyyy"),
                    slika_korisnika = s.slika_korisnika,

                }) 
                .ToList();
            return Ok(data);
        }
    }  
}
