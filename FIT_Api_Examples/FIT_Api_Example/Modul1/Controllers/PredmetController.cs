using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul1.Models;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using System.Runtime.CompilerServices;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class PredmetController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PredmetController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public Predmet Snimi([FromBody] PredmetSnimiVM x)
        {

            Predmet? obj;

            if (x.ID == 0)
            {
                obj = new Predmet();
                _dbContext.Add(obj);
            }
            else
            {
                obj = _dbContext.Predmet.Find(x.ID);
            }
            obj.Naziv = x.nazivPredmeta;
            obj.Sifra = x.sifraPredmeta;
            obj.ECTS = x.ectsBodovi;

        _dbContext.SaveChanges();//exceute sql -- insert into Predmet
            return obj;
        }

        [HttpGet]
        public List<PredmetGetAllVM> GetAll(string ? nazivFilter , float minProsjecnaOcjena)
        {
            var upit = _dbContext.Predmet

                .Where(p => (nazivFilter == null || p.Naziv.ToLower() == nazivFilter.ToLower()) ||
                (_dbContext.Ocjena.Where(o => o.PredmetID == p.ID)
                .Average(x => x.BrojacnaOcjena) <= minProsjecnaOcjena))

                .OrderBy(p => p.Naziv)
                .ThenBy(p => p.Sifra)
                .Take(100)
                .Select(p => new PredmetGetAllVM
                {
                    Id = p.ID,
                    ectsPredmeta = p.ECTS,
                    nazivPredmeta = p.Naziv,
                    prosjecnaOcjena = 0,
                    skracenicaPredmeta = p.Sifra,
                });

            return upit.ToList();
        }
    } 
}
