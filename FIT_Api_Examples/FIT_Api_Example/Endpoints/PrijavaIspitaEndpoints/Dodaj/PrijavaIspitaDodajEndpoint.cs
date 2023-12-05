using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.PrijavaIspitaEndpoints.Dodaj;

[Route("prijava-ispita")]
public class PrijavaIspitaDodajEndpoint: MyBaseEndpoint<PrijavaIspitaDodajRequest,  PrijavaIspitaDodajResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public PrijavaIspitaDodajEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpPost("dodaj")]
    public override async Task<PrijavaIspitaDodajResponse> Obradi([FromBody] PrijavaIspitaDodajRequest request, CancellationToken cancellationToken)
    {
        var noviObj = new Data.Models.PrijavaIspita
        {
            DatumPrijave = DateTime.Now,
            IspitID = request.IspitId,
            StudentID = request.StudentId
        };
        _applicationDbContext.Add(noviObj);//

        await _applicationDbContext.SaveChangesAsync(cancellationToken);//izvrašva se "insert into Ispit value ...."

        return new PrijavaIspitaDodajResponse
        {
            PrijavaIspitId = noviObj.ID
        };
    }
}