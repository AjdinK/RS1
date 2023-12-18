using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.StudentEndpoints.Snimi;

[Route("student")]
[MyAuthorization]
public class StudentSnimiEndpoint : MyBaseEndpoint<StudentSnimiRequest, int>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;

    public StudentSnimiEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
    }

    [HttpPost("snimi")]
    public override async Task<int> Obradi([FromBody] StudentSnimiRequest request, CancellationToken cancellationToken)
    {
       
        Data.Models.Student? student;
        if (request.ID == 0)
        {
            student = new Data.Models.Student();
            _applicationDbContext.Add(student);

            student.SlikaKorisnika = Config.SlikeURL + "empty.png";
        }
        else
        {
            student = _applicationDbContext.Student.Include(s => s.OpstinaRodjenja.drzava).FirstOrDefault(s => s.ID == request.ID);
            if (student == null)
                throw new Exception("pogresan ID");
        }

        student.Ime = request.Ime.RemoveTags();
        student.Prezime = request.Prezime.RemoveTags();
        //student.BrojIndeksa = request.BrojIndeksa;
        //student.DatumRodjenja = request.DatumRodjenja;
        student.OpstinaRodjenjaID = request.OpstinaRodjenjaID;

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return student.ID;
    }


}