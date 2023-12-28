using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.StudentEndpoints.Sedmica5;

[Route("student")]
[MyAuthorization]
public class StudentSedmica5Endpoint : MyBaseEndpoint<StudentSedmica5Request, List<Student>>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;
    public StudentSedmica5Endpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
    }

    [HttpGet("sedmica5")]
    public override async Task<List<Student>> Obradi([FromQuery] StudentSedmica5Request request, CancellationToken cancellationToken)
    {
   
        var data = _applicationDbContext.Student
              .Include(s => s.OpstinaRodjenja.drzava)
              .Where(x => request.ime_prezime == null || (x.Ime + " " + x.Prezime).StartsWith(request.ime_prezime) || (x.Prezime + " " + x.Ime)
              .StartsWith(request.ime_prezime))
              .OrderByDescending(s => s.ID)
              .AsQueryable();
        return data.Take(100).ToList();

    }
}