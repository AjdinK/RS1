using System.Diagnostics;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Data;
using FIT_Api_Example.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FIT_Api_Example.Helper.Auth
{
    public class MyAuthorizationAttribute : TypeFilterAttribute
    {
        public MyAuthorizationAttribute() : base(typeof(MyAuthorizationAsyncActionFilter))
        {
        }
    }
    public class MyAuthorizationAsyncActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var authService = context.HttpContext.RequestServices.GetService<MyAuthService>()!;
            var actionLogService= context.HttpContext.RequestServices.GetService<MyActionLogService>()!;

            if (!authService.IsLogiran())
            {
                context.Result = new UnauthorizedObjectResult("niste logirani na sistem");
                return;
            }

            MyAuthInfo myAuthInfo = authService.GetAuthInfo();

            if (myAuthInfo.korisnickiNalog.Is2FActive && !myAuthInfo.autentifikacijaToken.Is2FOtkljucano)
            {
                context.Result = new UnauthorizedObjectResult("niste otkljucali 2f");
                return;
            }

            await next();
            await actionLogService.Create(context.HttpContext);
        }
    }
}
