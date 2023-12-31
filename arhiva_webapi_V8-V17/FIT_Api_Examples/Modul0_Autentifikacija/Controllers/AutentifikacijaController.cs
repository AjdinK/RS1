﻿using System;
using System.Collections.Generic;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul0_Autentifikacija.ViewModels;
using FIT_Api_Examples.Modul2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static FIT_Api_Examples.Helper.AutentifikacijaAutorizacija.MyAuthTokenExtension;

namespace FIT_Api_Examples.Modul0_Autentifikacija.Controllers
{
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
        public ActionResult<LoginInformacije> Login([FromBody] LoginVM x)
        {
            //1- provjera logina
            KorisnickiNalog? logiraniKorisnik = _dbContext.KorisnickiNalog
                .FirstOrDefault(k =>
                 k.KorisnickoIme == x.korisnickoIme && k.Lozinka == x.lozinka);

            if (logiraniKorisnik == null)
            {
                //pogresan username i password
                return new LoginInformacije(null);
            }

            //2- generisati random string
            string randomString = TokenGenerator.Generate(10);
            string twoFactorCode = TokenGenerator.Generate(6);

            //3- dodati novi zapis u tabelu AutentifikacijaToken za logiraniKorisnikId i randomString
            var noviToken = new AutentifikacijaToken()
            {
                ipAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "",
                vrijednost = randomString,
                korisnickiNalog = logiraniKorisnik,
                vrijemeEvidentiranja = DateTime.Now,
                twoFactorCode = twoFactorCode,
            };

            _dbContext.Add(noviToken);
            _dbContext.SaveChanges();
            EmailLog.UspjesnoLogiranKorisnik(noviToken, Request.HttpContext);

            //4- vratiti token string
            return new LoginInformacije(noviToken);
        }

        [HttpGet("{code}")]
        public ActionResult Otkljucaj(string code)
        {

            var korisnickiNalog = HttpContext.GetLoginInfo().korisnickiNalog;
            if (korisnickiNalog == null)
            {
                return BadRequest("Korisnik nije logiran");
            }

            var token = _dbContext.AutentifikacijaToken.FirstOrDefault(t => t.twoFactorCode == code && t.korisnickiNalog.Id == korisnickiNalog.Id);
            if (token != null)
            {
                token.twoFactorCodeJelAktiviran = true;
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest("Error -> Pogresen URL");
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
}