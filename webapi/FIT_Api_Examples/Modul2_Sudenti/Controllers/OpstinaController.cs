using System.Collections.Generic;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul2.ViewModels;
using FIT_Api_Examples.Modul2_Sudenti.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class OpstinaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public OpstinaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult Snimi ([FromBody] OpstinaVM x)
        {
            // if (!HttpContext.GetLoginInfo().isLogiran)
            //     return BadRequest("nije logiran");
            Opstina? opstina;

            if (x.Id == 0)
            {
                opstina = new Opstina() { 
                    DrzavaId = x.DrzavaId,
                };
                _dbContext.Add(opstina);
            }
            else
            {
                opstina = _dbContext.Opstina.Find(x.Id);
                if (opstina == null)
                return BadRequest("Opstina ne postoji");
            }
            opstina.Description = x.Opis;
            opstina.DrzavaId = x.DrzavaId;
            _dbContext.SaveChanges();
            return Ok($"{opstina.Description} Uspjesno dodata");
        }

        [HttpGet]
        public ActionResult GetByDrzavaId(int DrzavaId)
        {
            var data = _dbContext.Opstina.Where(x => x.DrzavaId == DrzavaId)
                .OrderBy(s => s.DrzavaId)
                .Select(s => new OpstinaVM
                {
                    Id = s.Id,
                    Opis = s.Drzava.Naziv + " - " + s.Description,
                })
                .ToList();
            return Ok(data);
        }

        [HttpDelete]
        public ActionResult Brisi (int id ) {
            var opstina = _dbContext.Opstina.Find(id);
            
            if (opstina == null || id == 1){
              return BadRequest("Error");
            }
            _dbContext.Remove(opstina);
            _dbContext.SaveChanges();
            return Ok();
        }

        //[Autorizacija(true, true, true, true, true)]
        [HttpGet]
        public ActionResult GetByAll()
        {
            var data = _dbContext.Opstina
                .OrderBy(s => s.Id)
                .Select(s => new OpstinaVM
                {
                    Id = s.Id,
                    DrzavaId = s.Drzava.Id,
                    Opis = s.Drzava.Naziv + " - " + s.Description,
                })
                .ToList();
            return Ok(data);
        }
    }
}
