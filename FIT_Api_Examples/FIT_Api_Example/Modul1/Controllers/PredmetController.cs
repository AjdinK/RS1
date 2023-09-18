using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul1.Models;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;

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
        public List<CmbStavke> GetAll()
        {
            var data = _dbContext.Predmet
                .OrderBy(s => s.Naziv)
                .Select(s => new CmbStavke()
                {
                    id = s.ID,
                    opis = s.Naziv,
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
