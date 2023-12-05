using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.StudentEndpoints.ProfileImageSnimi;

[Route("student")]
public class StudentProfileImageSnimiEndpoint : MyBaseEndpoint<StudentProfileImageSnimiRequest, int>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public StudentProfileImageSnimiEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpPost("profile-image-snimi")]
    public override async Task<int> Obradi([FromBody] StudentProfileImageSnimiRequest request, CancellationToken cancellationToken)
    {
        Data.Models.Student? student = _applicationDbContext.Student.Include(s => s.OpstinaRodjenja.drzava).FirstOrDefault(s => s.ID == request.StudentId);

        if (student == null)
            throw new Exception("neispravan Student ID");
        if (request.SlikaStudenta.Length > 300 * 1000)
            throw new Exception("max velicina fajla je 300 KB");

        string ekstenzija = Path.GetExtension(request.SlikaStudenta.FileName);

        var filename = $"{Guid.NewGuid()}{ekstenzija}";

        await request.SlikaStudenta.CopyToAsync(new FileStream(Config.SlikeFolder + filename, FileMode.Create), cancellationToken);
        student.SlikaKorisnika = Config.SlikeURL + filename;
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return student.ID;
    }


}