using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.AuthEndpoints;

//[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class AutentifikacijaController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public AutentifikacijaController(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
    }


    [HttpPost]
    public ActionResult<MyAuthTokenExtension.LoginInformacije> Login([FromBody] AuthLoginRequest x)
    {
        //1- provjera logina
        KorisnickiNalog? logiraniKorisnik = _dbContext.KorisnickiNalog
            .FirstOrDefault(k =>
                k.KorisnickoIme == x.KorisnickoIme && k.Lozinka == x.Lozinka);

        if (logiraniKorisnik == null)
        {
            //pogresan username i password
            return new MyAuthTokenExtension.LoginInformacije(null);
        }

        //2- generisati random string
        string randomString = TokenGenerator.Generate(10);

        //3- dodati novi zapis u tabelu AutentifikacijaToken za logiraniKorisnikId i randomString
        var noviToken = new AutentifikacijaToken()
        {
            ipAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
            vrijednost = randomString,
            korisnickiNalog = logiraniKorisnik,
            vrijemeEvidentiranja = DateTime.Now
        };

        _dbContext.Add(noviToken);
        _dbContext.SaveChanges();

        //4- vratiti token string
        return new MyAuthTokenExtension.LoginInformacije(noviToken);
    }

    [HttpPost]
    public ActionResult Logout()
    {
        AutentifikacijaToken? autentifikacijaToken = HttpContext.GetAuthToken();

        if (autentifikacijaToken == null)
            return Ok();

        _dbContext.Remove(autentifikacijaToken);
        _dbContext.SaveChanges();
        return Ok();
    }

    [HttpGet]
    public ActionResult<AutentifikacijaToken?> Get()
    {
        AutentifikacijaToken? autentifikacijaToken = HttpContext.GetAuthToken();

        return autentifikacijaToken;
    }
}