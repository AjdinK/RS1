using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.Auth;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.AuthEndpoints.Get;

[Route("auth")]
public class AutGetEndpoint : MyBaseEndpoint<NoRequest, MyAuthInfo>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;
    public AutGetEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
    }

    [HttpPost("get")]
    public override async Task<MyAuthInfo> Obradi([FromBody] NoRequest request, CancellationToken cancellationToken)
    {
        AutentifikacijaToken? autentifikacijaToken = _authService.GetAuthInfo().autentifikacijaToken;

        return new MyAuthInfo(autentifikacijaToken);
    }


}