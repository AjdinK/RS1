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
        public ActionResult<Student> Snimi([FromBody] StudentSnimiVM x)
        {
            //if (!HttpContext.GetLoginInfo().isLogiran)
            //    return BadRequest("nije logiran");

            Student? obj;

            if (x.id == 0)
            {
                obj = new Student();
                obj.created_time = DateTime.Now;
                obj.slika_korisnika = Config.SlikeURL + "empty.png";
                _dbContext.Add(obj);   
            }
            else {
                obj = _dbContext.Student.Include("opstina_rodjenja").FirstOrDefault
                    (s => s.id == x.id);

                if (obj == null) 
                    return BadRequest("Pogresen ID");
            }

            obj.ime = x.ime;
            obj.prezime = x.prezime;
            obj.broj_indeksa = x.broj_indeksa;
            obj.opstina_rodjenja_id = x.opstina_rodjenja_id;
            

            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult<Student> BrisiByID (int id) {
            var obj = _dbContext.Student.Find(id);
            if (obj == null) return BadRequest("Pogresen ID");

            _dbContext.Student.Remove(obj);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public ActionResult<Student> BrisiByObj([FromBody] Student x)
        {
            var obj = _dbContext.Student.Find(x.id);
            if (obj == null) return BadRequest("Pogresen ID");
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
                .AsQueryable();
            return data.Take(100).ToList();
        }

    }
}
