using FIT_Api_Example.Data;
using FIT_Api_Example.Endpoints.StudentEndpoints.MaticnaKnjigaEndpoints.Get;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.AkademskaGodinaEndpoints.Get;

[Route("akademske-godine")]
public class AkademskeGodineGetEndpoint : MyBaseEndpoint<NoRequest, AkademskeGodineGetResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;
    public AkademskeGodineGetEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
    }

    [HttpGet()]
    public override async Task<AkademskeGodineGetResponse> Obradi([FromQuery]NoRequest request, CancellationToken cancellationToken)
    {
        var podaci = await _applicationDbContext.AkademskaGodina.Select(x=>new AkademskeGodineGetResponseAkGodine
        {
            Id = x.ID,
            Opis = x.Opis
        }).ToListAsync(cancellationToken);

        return new AkademskeGodineGetResponse
        {
            AkademskeGodine = podaci
        };
    }
}