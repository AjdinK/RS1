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

        public MyAuthService (ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsLogiran()
        {
            return GetAuthInfo().IsLogiran;
        }

        public bool IsAdmin()
        {
            return GetAuthInfo().KorisnickiNalog?.isAdmin?? false;
        }

        public bool IsStudentskaSluzba()
        {
            return GetAuthInfo().KorisnickiNalog?.isStudentskaSluzba ?? false;
        }

        public bool IsNastavnik()
        {
            return GetAuthInfo().KorisnickiNalog?.isNastavnik ?? false;
        }

        public MyAuthInfo GetAuthInfo()
        {
            string? AuthToken = _httpContextAccessor.HttpContext!.Request.Headers ["my-auth-token"];

            AutentifikacijaToken? AutentifikacijaToken = _applicationDbContext.AutentifikacijaToken
                .Include(x=>x.korisnickiNalog)
                .SingleOrDefault(x => x.vrijednost == AuthToken);

            return new MyAuthInfo (AutentifikacijaToken);
        }
    }

    public class MyAuthInfo
    {
        public AutentifikacijaToken? AutentifikacijaToken { get; set; }
        public MyAuthInfo (AutentifikacijaToken? AutentifikacijaToken)
        {
            this.AutentifikacijaToken = AutentifikacijaToken;
        }

        [JsonIgnore]
        public KorisnickiNalog? KorisnickiNalog => AutentifikacijaToken?.korisnickiNalog;

        public bool IsLogiran => KorisnickiNalog != null;

    }
}
