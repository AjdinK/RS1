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
        public Drzava Snimi([FromBody] DrzavaVM x) {
            Drzava? obj;
            if (x.Id == 0)
            {
                obj = new Drzava();
                _dbContext.Add(obj);
            }
            else {
                obj = _dbContext.Drzava.Find(x.Id);
            }
            obj.nazivDrzave = x.nazivDrzave;
            obj.skracenicaDrzave = x.skracenicaDrzave;
            _dbContext.SaveChanges();
            return obj;
        }

        [HttpDelete]
        public ActionResult Brisi (DrzavaBrisiVM x)
        {
            var obj = _dbContext.Drzava.Find(x.Id);
            if (obj == null) {
                return BadRequest("Obj not found");
            }
            _dbContext.Drzava.Remove(obj);
            _dbContext.SaveChanges();
            return Ok();
           
        }

        [HttpGet]
        public ActionResult GetAll(string ? nazivFilter)
        {
            var data = _dbContext.Drzava.Where(d => nazivFilter == null ||d.nazivDrzave.ToLower().Contains(nazivFilter.ToLower()))
                .OrderBy(s => s.Id)
                .Select(s => new DrzavaVM()
                {
                    Id = s.Id,
                    nazivDrzave = s.nazivDrzave,
                    skracenicaDrzave = s.skracenicaDrzave
                })
                .AsQueryable();
            return Ok (data.Take(100).ToList());
        }
    }
}
