using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.IspitEndpoints.Obrisi;

[Route("ispit")]
public class IspitObrisiEndpoint: MyBaseEndpoint<IspitObrisiRequest,  IspitObrisiResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public IspitObrisiEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpDelete("obrisi")]
    public override async Task<IspitObrisiResponse> Obradi([FromQuery] IspitObrisiRequest request, CancellationToken cancellationToken)
    {

        var ispiti = _applicationDbContext.Ispit.FirstOrDefault(x => x.ID == request.IspitID);

        if (ispiti == null)
        {
            throw new Exception("nije pronadjen ispit za id = " + request.IspitID);
        }

        _applicationDbContext.Remove(ispiti);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return new IspitObrisiResponse
        {
               
        };
    }
}