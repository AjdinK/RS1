using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.StudentEndpoints.GetAll;

[Route("student")]
public class StudentGetAllEndpoint: MyBaseEndpoint<StudentSedmica5Request,  StudentGetAllResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;

    public StudentGetAllEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
    }

    [HttpGet("get-all")]
  
    public override async Task<StudentGetAllResponse> Obradi([FromQuery] StudentSedmica5Request request, CancellationToken cancellationToken)
    {
        if (!_authService.IsLogiran())
        {
            throw new Exception("nije logiran");
        }

        KorisnickiNalog korisnickiNalog = _authService.GetAuthInfo().korisnickiNalog!;
        if (!(korisnickiNalog.isStudentskaSluzba || korisnickiNalog.isAdmin || korisnickiNalog.isProdekan))
        {
            throw new Exception("nema pravo pristupa");
        }

        var student = await _applicationDbContext.Student
            .OrderByDescending(x => x.ID)
            .Select(x=>new StudentGetAllResponseStudent()
            {
                ID = x.ID,
                DatumRodjenja = x.DatumRodjenja,
                Ime = x.Ime,
                Prezime =  x.Prezime,
                KorisnickoIme = x.KorisnickoIme,
                OpstinaRodjenjaDrzava = x.OpstinaRodjenja.drzava.Naziv,
                OpstinaRodjenjaNaziv = x.OpstinaRodjenja.description,
                SlikaKorisnika = x.SlikaKorisnika
            })
            .ToListAsync(cancellationToken: cancellationToken);

        return new StudentGetAllResponse
        {
            Studenti = student
        };
    }
}