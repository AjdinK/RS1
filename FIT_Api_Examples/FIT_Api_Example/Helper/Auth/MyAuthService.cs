﻿using System.Text.Json.Serialization;
using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Helper.Auth
{
    public class MyAuthService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MyAuthService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public bool IsLogiran()
        {
            return GetAuthInfo().isLogiran;
        }

        public bool IsAdmin()
        {
            return GetAuthInfo().korisnickiNalog?.isAdmin??false;
        }

        public bool IsStudentskaSluzba()
        {
            return GetAuthInfo().korisnickiNalog?.isStudentskaSluzba ?? false;
        }

        public bool IsNastavnik()
        {
            return GetAuthInfo().korisnickiNalog?.isNastavnik ?? false;
        }


        public MyAuthInfo GetAuthInfo()
        {
            string? authToken = _httpContextAccessor.HttpContext!.Request.Headers["my-auth-token"];

            AutentifikacijaToken? autentifikacijaToken = _applicationDbContext.AutentifikacijaToken
                .Include(x=>x.korisnickiNalog)
                .SingleOrDefault(x => x.vrijednost == authToken);

            return new MyAuthInfo(autentifikacijaToken);
        }
    }

    public class MyAuthInfo
    {
        public MyAuthInfo(AutentifikacijaToken? autentifikacijaToken)
        {
            this.autentifikacijaToken = autentifikacijaToken;
        }

        [JsonIgnore]
        public KorisnickiNalog? korisnickiNalog => autentifikacijaToken?.korisnickiNalog;
        public AutentifikacijaToken? autentifikacijaToken { get; set; }

        public bool isLogiran => korisnickiNalog != null;

    }
}
