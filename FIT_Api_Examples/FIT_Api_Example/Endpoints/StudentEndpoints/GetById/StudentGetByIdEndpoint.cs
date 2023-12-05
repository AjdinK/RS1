using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.StudentEndpoints.GetById;

[Route("student")]
public class StudentGetByIdEndpoint: MyBaseEndpoint<int, StudentGetByIdResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public StudentGetByIdEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpGet("{id}")]
    public override async Task<StudentGetByIdResponse> Obradi(int id, CancellationToken cancellationToken)
    {
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