using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Endpoints.AuthEndpoints.Login;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.AuthEndpoints.Logout;

[Route("auth")]
public class AuthLogoutEndpoint : MyBaseEndpoint<NoRequest, NoResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;

    public AuthLogoutEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
    }

    [HttpPost("logout")]
    public override async Task<NoResponse> Obradi([FromBody] NoRequest request, CancellationToken cancellationToken)
    {
        AutentifikacijaToken? autentifikacijaToken = _authService.GetAuthInfo().autentifikacijaToken;

        if (autentifikacijaToken == null)
            return new NoResponse();

        _applicationDbContext.Remove(autentifikacijaToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return new NoResponse();
    }


}