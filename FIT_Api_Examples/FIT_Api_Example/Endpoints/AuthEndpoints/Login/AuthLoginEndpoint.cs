using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.AuthEndpoints.Login;

[Route("auth")]
public class AuthLoginEndpoint : MyBaseEndpoint<AuthLoginRequest, MyAuthInfo>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public AuthLoginEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpPost("login")]
    public override async Task<MyAuthInfo> Obradi([FromBody] AuthLoginRequest request, CancellationToken cancellationToken)
    {
        //1- provjera logina
        KorisnickiNalog? logiraniKorisnik = await _applicationDbContext.KorisnickiNalog
            .FirstOrDefaultAsync(k =>
                k.KorisnickoIme == request.KorisnickoIme && k.Lozinka == request.Lozinka, cancellationToken);

        if (logiraniKorisnik == null)
        {
            //pogresan username i password
            return new MyAuthInfo(null);
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

        _applicationDbContext.Add(noviToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        //4- vratiti token string
        return new MyAuthInfo(noviToken);
    }


}