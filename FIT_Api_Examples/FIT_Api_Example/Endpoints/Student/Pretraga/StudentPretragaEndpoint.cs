using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.Student.Pretraga
{
    [Route("student-pretraga")]
    public class StudentPretragaEndpoint: MyBaseEndpoint<StudentPretragaRequest,  StudentPretragaResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StudentPretragaEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public override async Task<StudentPretragaResponse> Obradi([FromQuery]StudentPretragaRequest request)
        {
            var student = await _applicationDbContext.Student.Where(x =>
                    request.Pretraga == null || 
                    (x.Ime + " " + x.Prezime).StartsWith(request.Pretraga) ||
                    (x.Prezime + " " + x.Ime).StartsWith(request.Pretraga) 
                    )
                .OrderByDescending(x=>x.ID)
                .Select(x=>new StudentPretragaResponseStudent()
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
                .ToListAsync();

            return new StudentPretragaResponse
            {
                Studenti = student
            };
        }
    }
}
