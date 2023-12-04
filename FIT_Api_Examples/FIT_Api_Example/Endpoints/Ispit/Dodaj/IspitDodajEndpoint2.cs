using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.Ispit.Dodaj
{
    [Route("ispit-dodaj")]

    public class IspitDodajEndpoint2 : MyBaseEndpoint<IspitDodajRequest, IspitDodajResponse>
    {
        private readonly ApplicationDbContext _context;
        public IspitDodajEndpoint2(ApplicationDbContext _context) {
            this._context = _context; 
        }
        public override Task<IspitDodajResponse> Obradi (IspitDodajRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
