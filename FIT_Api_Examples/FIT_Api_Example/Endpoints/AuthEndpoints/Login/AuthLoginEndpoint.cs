using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.AuthEndpoints.Login;

[Route("auth")]
public class AuthLoginEndpoint : MyBaseEndpoint<AuthLoginRequest, MyAuthInfo>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyEmailSenderService _emailSenderService;


    public AuthLoginEndpoint(ApplicationDbContext applicationDbContext, MyEmailSenderService emailSenderService)
    {
        _applicationDbContext = applicationDbContext;
        _emailSenderService = emailSenderService;
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

        string? twoFKey = null;

        if (logiraniKorisnik.Is2FActive)
        {
            twoFKey = TokenGenerator.Generate(4);
            _emailSenderService.Posalji("xeceyo7099@mcenb.com", "2f", $"Vasi 2f kljuc je {twoFKey}", false);
        }

        //2- generisati random string
        string randomString = TokenGenerator.Generate(10);

        //3- dodati novi zapis u tabelu AutentifikacijaToken za logiraniKorisnikId i randomString
        var noviToken = new AutentifikacijaToken()
        {
            ipAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
            vrijednost = randomString,
            korisnickiNalog = logiraniKorisnik,
            vrijemeEvidentiranja = DateTime.Now,
            TwoFKey= twoFKey
        };

        _applicationDbContext.Add(noviToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        //4- vratiti token string
        return new MyAuthInfo(noviToken);
    }


}