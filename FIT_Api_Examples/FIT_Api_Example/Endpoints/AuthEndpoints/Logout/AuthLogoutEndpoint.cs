using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Endpoints.AuthEndpoints.Login;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.Auth;
using FIT_Api_Example.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.AuthEndpoints.Logout;

[Route("auth")]
public class AuthLogoutEndpoint : MyBaseEndpoint<AuthLogoutRequest, NoResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;
    private readonly IHubContext<SignalRHub> _hubContext;

    public AuthLogoutEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService, IHubContext<SignalRHub> hubContext)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
        _hubContext = hubContext;
    }

    [HttpPost("logout")]
    public override async Task<NoResponse> Obradi([FromBody] AuthLogoutRequest request, CancellationToken cancellationToken)
    {
        AutentifikacijaToken? autentifikacijaToken = _authService.GetAuthInfo().autentifikacijaToken;

        if (autentifikacijaToken == null)
            return new NoResponse();

        await _hubContext.Groups.AddToGroupAsync(
            request.SignalRConnectionID,
            autentifikacijaToken.korisnickiNalog.KorisnickoIme,
            cancellationToken
        );

        _applicationDbContext.Remove(autentifikacijaToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return new NoResponse();
    }


}