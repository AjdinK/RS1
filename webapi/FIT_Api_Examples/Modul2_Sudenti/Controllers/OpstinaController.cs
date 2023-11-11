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
        public ActionResult<Opstina> Snimi ([FromBody] OpstinaVM x)
        {
            // if (!HttpContext.GetLoginInfo().isLogiran)
            //     return BadRequest("nije logiran");

            Opstina  opstina = new Opstina () {
                Description = x.Opis,
                DrzavaId = x.DrzavaId,
            };
            
            _dbContext.Add(opstina);
            _dbContext.SaveChanges();
            return opstina;
        }

        [HttpGet]
        public ActionResult GetByDrzava(int drzava_id)
        {
            var data = _dbContext.Opstina.Where(x => x.DrzavaId == drzava_id)
                .OrderBy(s => s.Description)
                .Select(s => new OpstinaVM
                {
                    DrzavaId = s.Id,
                    Opis = s.Drzava.Naziv + " - " + s.Description,
                })
                .ToList();
            return Ok(data);
        }

        //[Autorizacija(true, true, true, true, true)]
        [HttpGet]
        public ActionResult GetByAll()
        {
            var data = _dbContext.Opstina
                .OrderBy(s => s.Id)
                .Select(s => new OpstinaVM
                {
                    DrzavaId = s.Id,
                    Opis = s.Drzava.Naziv + " - " + s.Description,
                })
                .ToList();
            return Ok(data);
        }
    }
}
