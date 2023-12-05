using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using Microsoft.AspNetCore.Mvc;
using FIT_Api_Example.Data.Models;

namespace FIT_Api_Example.Endpoints.DrzavaEndpoints;

//[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class DrzavaController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public DrzavaController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpPost]
    public Drzava Snimi([FromBody] DrzavaSnimiRequest x)
    {
        Drzava? objekat;

        if (x.id == 0)
        {
            objekat = new Drzava();
            _dbContext.Add(objekat);//priprema sql
        }
        else
        {
            objekat = _dbContext.Drzava.Find(x.id);
        }

        objekat.Naziv = x.naziv;
        objekat.Skracenica = x.skracenica;

        _dbContext.SaveChanges();
        return objekat;
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        var data = _dbContext.Drzava
            .OrderBy(s => s.Naziv)
            .Select(s => new DrzavaGetAllResponse()
            {
                Id = s.ID,
                Skracenica = s.Skracenica,
                Naziv = s.Naziv,
            })
            .Take(100);
        return Ok(data.ToList());
    }
}