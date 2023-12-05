using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.PredmetEndpoints;

//[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class PredmetController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public PredmetController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }



    [HttpPost]
    public Predmet Snimi([FromBody] PredmetSnimiRequest x)
    {
        Predmet? objekat;

        if (x.Id == 0)
        {
            objekat = new Predmet();
            _dbContext.Add(objekat);//priprema sql
        }
        else
        {
            objekat = _dbContext.Predmet.Find(x.Id);
        }

        objekat.Naziv = x.Naziv;
        objekat.Sifra = x.Sifra;
        objekat.Ects = x.Ects;

        _dbContext.SaveChanges(); //exceute sql -- update Predmet set ... where...
        return objekat;
    }



    [HttpGet]
    public List<PredmetGetAllResponse> GetAll(string? f, float min_prosjecna_ocjena)
    {
        var pripremaUpita = _dbContext.Predmet
            .Where(p => f == null || p.Naziv.ToLower().StartsWith(f.ToLower())
                /*  &&

                  (

                      (_dbContext.Ocjena.Where(o=>o.PredmetID==p.ID).Average(x=>(int?)x.BrojcanaOcjena)??0)

                      <= min_prosjecna_ocjena)*/

            )
            .OrderBy(p => p.Naziv)
            .ThenBy(p => p.Sifra)
            .Take(100)
            .Select(p => new PredmetGetAllResponse
            {
                ID = p.ID,
                ECTS = p.Ects.ToString(),
                Naziv = p.Naziv,
                Sifra = p.Sifra,
                ProsjecnaOcjena = 0
            });


        return pripremaUpita
            .ToList(); //exceute sql -- select top 100 * from Predmet where Naziv like 'A%' order by Naziv, sifra
    }
}