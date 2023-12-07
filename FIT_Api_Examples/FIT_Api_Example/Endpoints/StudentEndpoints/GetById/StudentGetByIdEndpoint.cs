using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.StudentEndpoints.GetById;

[Route("student")]
public class StudentGetByIdEndpoint: MyBaseEndpoint<int, StudentGetByIdResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;
    public StudentGetByIdEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
    }

    [HttpGet("{id}")]
    public override async Task<StudentGetByIdResponse> Obradi(int id, CancellationToken cancellationToken)
    {
        if (!_authService.IsLogiran())
        {
            throw new Exception("nije logiran");
        }
        var student = await _applicationDbContext.Student
            .OrderByDescending(x => x.ID)
            .Select(x=>new StudentGetByIdResponse
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
            .SingleAsync(x=>x.ID == id, cancellationToken: cancellationToken);

        return student;
    }
}