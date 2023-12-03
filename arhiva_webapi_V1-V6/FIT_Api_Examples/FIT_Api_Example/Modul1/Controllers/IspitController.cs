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
    public class IspitController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public IspitController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

     
        [HttpPost]
        public Ispit Add([FromBody] IspitAddVM x)
        {
            var newIspit = new Ispit
            {
                Naziv = x.Naziv,
                Datum = x.Datum,
                PredmetID = x.PredmetID,
            };

            _dbContext.Add(newIspit);
            _dbContext.SaveChanges();
            return newIspit;
        }

        [HttpGet]
        public List<CmbStavke> GetAll()
        {
            var data = _dbContext.Ispit
                .OrderBy(s => s.Naziv)
                .Select(s => new CmbStavke()
                {
                    id = s.Id,
                    opis = s.Naziv,
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
