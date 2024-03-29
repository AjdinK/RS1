﻿using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.Auth;
using FIT_Api_Example.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.AuthEndpoints.Login;

[Route("auth")]
public class AuthLoginEndpoint : MyBaseEndpoint<AuthLoginRequest, MyAuthInfo>
{
    private readonly ApplicationDbContext _applicationDbContext;

    private readonly MyEmailSenderService _emailSenderService;
    private readonly IHubContext<SignalRHub> _hubContext;

    public AuthLoginEndpoint(ApplicationDbContext applicationDbContext, MyEmailSenderService emailSenderService, IHubContext<SignalRHub> hubContext)
    {
        _applicationDbContext = applicationDbContext;
        _emailSenderService = emailSenderService;
        _hubContext = hubContext;
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
            twoFKey = TokenGenerator.Generate(6);
            _emailSenderService.Posalji("ajdin.kuduzovic@gmail.com", //test email
            "2f",
            $"Vasi 2f kljuc je {twoFKey}",
            false);
        }

        //2- generisati random string za authToken
        string randomString = TokenGenerator.Generate(10);

        //3- dodati novi zapis u tabelu AutentifikacijaToken za logiraniKorisnikId i randomString
        var noviToken = new AutentifikacijaToken()
        {
            IpAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
            Vrijednost = randomString,
            KorisnickiNalog = logiraniKorisnik,
            VrijemeEvidentiranja = DateTime.Now,
            TwoFKey = twoFKey
        };

        _applicationDbContext.Add(noviToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        await _hubContext.Groups.AddToGroupAsync(
            request.SignalRConnectionID,
            noviToken.KorisnickiNalog.KorisnickoIme,
            cancellationToken
        );

        //4- vratiti token string
        return new MyAuthInfo(noviToken);
    }
}