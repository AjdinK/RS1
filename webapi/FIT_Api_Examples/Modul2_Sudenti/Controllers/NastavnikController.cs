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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class NastavnikController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public NastavnikController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{guid}")]
        public ActionResult Aktivacija (string guid) {
            var nastavnik = _dbContext.Nastavnik.FirstOrDefault(n => n.AktivacijaGUID == guid);
            if (nastavnik != null){
                nastavnik.isAktiviran = true;
                _dbContext.SaveChanges();
                return Redirect("http://localhost:4200/");
            }   
            return BadRequest("Error -> Pogresen URL");     
        }

        [HttpPost]
        [Autorizacija (true,true,true,false,true)]
        public ActionResult Snimi([FromBody] NastavnikGetAllVM x)
        {
            Nastavnik? nastavnik;
            if (x.id == 0)
            {
                nastavnik = new Nastavnik
                {
                    lozinka = "test",
                    
                };
                _dbContext.Add(nastavnik);
                nastavnik.AktivacijaGUID = Guid.NewGuid().ToString();
            }
            else
            {
                nastavnik = _dbContext.Nastavnik.FirstOrDefault(n => n.id == x.id);
            }

            if (nastavnik == null)
                return BadRequest("pogresan ID");

            nastavnik.ime = x.ime.RemoveTags();
            nastavnik.prezime = x.prezime.RemoveTags();
            nastavnik.korisnickoIme = x.korisnickoIme;
            nastavnik.Email = x.Email;

            // if (!string.IsNullOrEmpty(x.slika_korisnika_nova_base64))
            // {
            //     //slika se snima u db
            //     byte[]? slika_bajtovi = x.slika_korisnika_nova_base64?.ParsirajBase64();
            //     nastavnik.slika_korisnika_bajtovi = slika_bajtovi;

            //     if (slika_bajtovi == null)
            //         return BadRequest("format slike nije base64");

            //     //slika se snima na File System
            //     Fajlovi.Snimi(slika_bajtovi, "slike_korisnika/" + nastavnik.id + ".png");
            // }
            EmailLog.noviNastavnik (nastavnik , HttpContext);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
