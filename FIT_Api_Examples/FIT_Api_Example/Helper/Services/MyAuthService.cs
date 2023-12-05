using FIT_Api_Example.Data;

namespace FIT_Api_Example.Helper.Services
{
    public class MyAuthService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MyAuthService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        public bool JelLogiran()
        {
            string? authToken = _httpContextAccessor.HttpContext!.Request.Headers["my-auth-token"];


            return authToken == "wHxquBw8ZR";
        }
    }
}
