using FIT_Api_Example.Data;
using FIT_Api_Example.Modul2_IspitOcjene.Models;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul2_IspitOcjene.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class IspitController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public IspitController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet()]
        public ActionResult Proba0(string? naziv)
        {
            var rezultat = _applicationDbContext
                .Ispit
                .Where(x=>naziv == null || x.Predmet.Naziv.ToLower().StartsWith(naziv.ToLower()))
                .Select(x => new IspitGet
                {
                    IdIspita = x.ID,
                    Komnt = x.Komentar,
                    Satnica = x.DatumVrijemeIspita,
                    PredmetId = x.PredmetID,
                    PuniNaziv = x.Predmet.Naziv,
                    SifraPredmeta = x.Predmet.Sifra,
                    Bodovi = x.Predmet.Ects
                }).ToList();

            return Ok(rezultat);
        }

        [HttpGet()]
        public object Proba1(string a, string b)
        {
            return "neka poruka";
        }

        [HttpPut()]
        public object Proba2(string a, string b)
        {
            return "neka poruka 2";
        }

        [HttpPost()]
        public object Proba3_query_parametrima(int predmetId, DateTime satnica, string komentar)
        {
            var noviObj = new Ispit
            {
                PredmetID = predmetId,
                DatumVrijemeIspita = satnica,
                Komentar = komentar
            };
            _applicationDbContext.Ispit.Add(noviObj);//

            _applicationDbContext.SaveChanges();//izvrašva se "insert into Ispit value ...."

            return noviObj;
        }

        [HttpPost()]
        public object Proba3_body_parametrima([FromBody] IspitPost podaci)
        {
            var noviObj = new Ispit
            {
                PredmetID = podaci.PredmetId,
                DatumVrijemeIspita = podaci.Satnica,
                Komentar = podaci.Komentar
            };
            _applicationDbContext.Ispit.Add(noviObj);//

            _applicationDbContext.SaveChanges();//izvrašva se "insert into Ispit value ...."

            return noviObj;
        }

        [HttpDelete()]
        public object Proba4(string a, string b)
        {
            return "neka poruka 4";
        }

        [HttpPatch()]
        public object Proba5(string a, string b)
        {
            return "neka poruka 5";
        }
    }
}
