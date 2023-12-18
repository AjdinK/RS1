using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.StudentEndpoints.MaticnaKnjigaEndpoints.Get;

[Route("student/maticna-knjiga")]
[MyAuthorization]
public class StudentMaticnaKnjigaGetEndpoint : MyBaseEndpoint<int, StudentMaticnaKnjigaGetResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;
    public StudentMaticnaKnjigaGetEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
    }

    [HttpGet("{id}")]
    public override async Task<StudentMaticnaKnjigaGetResponse> Obradi(int id, CancellationToken cancellationToken)
    {
        var student = await _applicationDbContext.Student.FindAsync(id);

        if (student is null)
            throw new Exception("not found student for id = " + id);

        var result = new StudentMaticnaKnjigaGetResponse
        {
            Id = student.ID,
            Ime = student.Ime,
            Prezime = student.Prezime,
            UpisaneGodine = await _applicationDbContext
                .UpisAkGodine
                .Where(x=>x.StudentId == id)
                .Select(x=>new StudentMaticnaKnjigaGetResponseUpisaneGodine
                {
                    AkademskaGodina = x.AkademskaGodina.Opis,
                    GodinaStudija = x.Godinastudina + "",
                    KorisnikEvidentirao = new StudentMaticnaKnjigaGetResponseUpisaneGodineKorisnik
                    {
                        Ime = x.EvidentiraoKorisnik.KorisnickoIme, //todo: dodati ime i prezime u korisnik
                        Prezime = x.EvidentiraoKorisnik.KorisnickoIme,//todo: dodati ime i prezime u korisnik
                        Id = x.Id
                    },
                    Id = x.Id,
                    Obnova = x.JelObnova,
                    ZimskiSemestarOvjera = x.DatumOvjeraZimski,
                    ZimskiSemestarUpis = x.DatumUpisZimski,
                })
                .ToListAsync(cancellationToken)
        };
        


        return result;
    }
}