using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.IspitEndpoints.Dodaj;

[Route("ispit")]
public class IspitDodajEndpoint: MyBaseEndpoint<IspitDodajRequest,  IspitDodajResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public IspitDodajEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpPost("dodaj")]
    public override async Task<IspitDodajResponse> Obradi([FromBody]IspitDodajRequest request, CancellationToken cancellationToken)
    {
        var noviObj = new Data.Models.Ispit
        {
            PredmetID = request.PredmetId,
            DatumVrijemeIspita = request.Satnica,
            Komentar = request.Komentar
        };
        _applicationDbContext.Ispit.Add(noviObj);//

        await _applicationDbContext.SaveChangesAsync(cancellationToken);//izvrašva se "insert into Ispit value ...."

        return new IspitDodajResponse
        {
            IspitId = noviObj.ID
        };
    }


}