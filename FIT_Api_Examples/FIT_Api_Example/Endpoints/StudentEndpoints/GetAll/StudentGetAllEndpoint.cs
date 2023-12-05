using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.StudentEndpoints.GetAll;

[Route("student")]
public class StudentGetAllEndpoint: MyBaseEndpoint<StudentSedmica5Request,  StudentGetAllResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public StudentGetAllEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpGet("get-all")]
    public override async Task<StudentGetAllResponse> Obradi([FromQuery] StudentSedmica5Request request, CancellationToken cancellationToken)
    {
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