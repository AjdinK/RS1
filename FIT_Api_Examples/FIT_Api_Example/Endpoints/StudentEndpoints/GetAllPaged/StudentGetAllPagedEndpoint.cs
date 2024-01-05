using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Endpoints.StudentEndpoints.GetAll;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.StudentEndpoints.GetAllPaged;

[Route("student")]
[MyAuthorization]
public class StudentGetAllPagedEndpoint : MyBaseEndpoint<StudentGetAllPagedRequest, StudentGetAllPagedResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;

    public StudentGetAllPagedEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
    }

    [HttpGet("get-all-paged")]
    public override async Task<StudentGetAllPagedResponse> Obradi([FromQuery] StudentGetAllPagedRequest request, CancellationToken cancellationToken)
    {
        IQueryable<StudentGetAllPagedResponseStudent> student = _applicationDbContext.Student
            .OrderByDescending(x => x.ID)
            .Where(x => x.Obrisan == false)
            .Select(x => new StudentGetAllPagedResponseStudent()
            {
                ID = x.ID,
                DatumRodjenja = x.DatumRodjenja,
                Ime = x.Ime,
                Prezime = x.Prezime,
                KorisnickoIme = x.KorisnickoIme,
                OpstinaRodjenjaDrzava = x.OpstinaRodjenja.drzava.Naziv,
                OpstinaRodjenjaNaziv = x.OpstinaRodjenja.description,
                SlikaKorisnika = x.SlikaKorisnika,
                OpstinaRodjenjaID = x.OpstinaRodjenjaID
            });

        var dataOfOnePage = PagedList<StudentGetAllPagedResponseStudent>.Create(student, request.PageNumber, request.PageSize);

        return new StudentGetAllPagedResponse
        {
            Studenti = dataOfOnePage
        };
    }
}