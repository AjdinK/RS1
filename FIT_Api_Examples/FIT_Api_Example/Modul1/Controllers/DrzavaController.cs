using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul2.Controllers
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
        public Drzava Snimi([FromBody] DrzavaSnimiVM x) {
            Drzava? obj;
            if (x.Id == 0)
            {
                obj = new Drzava();
                _dbContext.Drzava.Add(obj);
            }
            else {
                obj = _dbContext.Drzava.Find(x.Id);
            }
            obj.naziv = x.nazivDrzave;
            obj.skracenica = x.skracenicaDrzave;
            _dbContext.SaveChanges();
            return obj;
        }

        [HttpGet]
        public List<CmbStavke> GetAll()
        {
            var data = _dbContext.Drzava
                .OrderBy(s => s.naziv)
                .Select(s => new CmbStavke()
                {
                    id = s.id,
                    opis = s.naziv,
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
