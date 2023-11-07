using System.Collections.Generic;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul2_Sudenti.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class DrzavaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public DrzavaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<Drzava> Snimi ([FromBody] DrzavaVM x)
        {
            // if (!HttpContext.GetLoginInfo().isLogiran)
            //     return BadRequest("nije logiran");
            Drzava? drzava ;

            if (x.Id == 0){
                drzava = new Drzava ();
                _dbContext.Add(drzava);
            }
            else {
                drzava = _dbContext.Drzava.Find(x.Id);
            }

            drzava.Naziv = x.Naziv;
            drzava.Skracenica = x.Skracenica;
            _dbContext.SaveChanges();
            return drzava;
        }

        [HttpDelete]
        public ActionResult Brisi (int id) {
            var drzava = _dbContext.Drzava.Find(id);

            if (drzava != null){
                _dbContext.Remove(drzava);
                _dbContext.SaveChanges();
                return Ok ($"{drzava.Naziv} Uspjesno izbrisana");
            }

            return BadRequest("Error -> ID Drzave ne postoji");
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _dbContext.Drzava
                .OrderBy(s => s.Id)
                .Select(s => new DrzavaVM
                {
                    Id = s.Id,
                    Naziv = s.Naziv,
                    Skracenica = s.Skracenica
                })
                .ToList();
            return Ok(data);
        }
    }
}
