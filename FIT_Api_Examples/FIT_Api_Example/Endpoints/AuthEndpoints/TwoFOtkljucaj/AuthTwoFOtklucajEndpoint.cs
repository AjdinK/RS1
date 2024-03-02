using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.Auth;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.AuthEndpoints.TwoFOtkljucaj;

[Route("auth")]
public class AuthTwoFOtklucajEndpoint : MyBaseEndpoint<AuthTwoFOtkljucajRequest, NoResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;

    public AuthTwoFOtklucajEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
    }

    [HttpPost("2f-otklucaj")]
    public override async Task<NoResponse> Obradi([FromBody] AuthTwoFOtkljucajRequest request,
        CancellationToken cancellationToken)
    {
        if (!_authService.GetAuthInfo().IsLogiran)
        {
            throw new Exception("niste logirani");
        }

        var AuthToken = _authService.GetAuthInfo().AutentifikacijaToken;
        if (AuthToken is null)
            throw new ArgumentNullException(nameof(AuthToken));

        if (request.Kljuc == AuthToken.TwoFKey)
        {
            AuthToken.Is2FOtkljucano = true;
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        return new NoResponse();
    }
}