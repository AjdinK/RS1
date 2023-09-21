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
        public Predmet Add([FromBody] PredmetAddVM x)
        {
            var newPredmet = new Predmet
            {
                Naziv = x.nazivPredmeta,
                Skracenica = x.skracenicaPredmeta,
                ECTS = x.ectsPredmeta,
            };

            _dbContext.Add(newPredmet);
            _dbContext.SaveChanges();
            return newPredmet;
        }

        [HttpGet]
        public List<PredmetGetAllVM> GetAll(string ? nazivFilter , float minProsjecnaOcjena)
        {
            var upit = _dbContext.Predmet
                .Where(p => (nazivFilter == null || p.Naziv.ToLower() == nazivFilter.ToLower()) &&  
                (_dbContext.Ocjena.Where(o=> o.PredmetID == p.ID).Average(x=>x.BrojacnaOcjena)<=minProsjecnaOcjena))
                .OrderBy(p => p.Naziv)
                .ThenBy(p => p.Skracenica)
                .Take(100)
                .Select(p => new PredmetGetAllVM
                {
                    ectsPredmeta = p.ECTS,
                    nazivPredmeta = p.Naziv,
                    prosjecnaOcjena = 0,
                    skracenicaPredmeta = p.Skracenica,
                });

            return upit.ToList();
        }
    }

    public class PredmetGetAllVM
    {
        public string nazivPredmeta { get; set; }
        public string skracenicaPredmeta { get; set; }
        public int ectsPredmeta { get; set; }
        public float prosjecnaOcjena { get; set; }
    }
}
