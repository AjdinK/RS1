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
        public ActionResult Snimi ([FromBody] DrzavaVM x)
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
                if (drzava == null)
                return BadRequest ("Drzava ne postoji");
            }

            drzava.Naziv = x.Naziv;
            drzava.Skracenica = x.Skracenica;
            _dbContext.SaveChanges();
            return Ok($"{drzava.Naziv} Uspjesno dodata");
        }

        [HttpDelete]
        public ActionResult Brisi (int id) {
            var drzava = _dbContext.Drzava.Find(id);

            if (drzava == null || id == 1){
               return BadRequest("Error -> Drzava ne postoji");
            }
            _dbContext.Remove(drzava);
            _dbContext.SaveChanges();
            return Ok ($"{drzava.Naziv} Uspjesno izbrisana");
        }

        [HttpGet]
        public ActionResult GetAll () {

            var data = _dbContext.Drzava
            .OrderBy(d => d.Id)
            .Select(d => new DrzavaVM {
                Id = d.Id,
                Naziv = d.Naziv,
                Skracenica = d.Skracenica ?? "Not_Set"
            }).ToList();
            
            return Ok (data);
        }
    }
}
