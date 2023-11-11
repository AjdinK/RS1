using System.Collections.Generic;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul2.ViewModels;
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
        public ActionResult<Opstina> Add ([FromBody] OpstinaVM x)
        {
            // if (!HttpContext.GetLoginInfo().isLogiran)
            //     return BadRequest("nije logiran");

            Opstina  opstina = new () {
                Description = x.Opis,
                Id = x.Id,
            };

            _dbContext.Add(opstina);
            _dbContext.SaveChanges();
            return opstina;
        }

        [HttpGet]
        public ActionResult GetByDrzava(int DrzavaId)
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
            if (opstina != null){
                _dbContext.Remove(opstina);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest("Error");
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
                    Opis = s.Drzava.Naziv + " - " + s.Description,
                })
                .ToList();
            return Ok(data);
        }
    }
}
