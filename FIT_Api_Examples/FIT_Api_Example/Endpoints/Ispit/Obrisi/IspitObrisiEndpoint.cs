using FIT_Api_Example.Data;
using FIT_Api_Example.Endpoints.Ispit.Pretraga;
using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.Ispit.Obrisi
{
    [Route("ispit-obrisi")]
    public class IspitObrisiEndpoint: MyBaseEndpoint<IspitObrisiRequest,  IspitObrisiResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public IspitObrisiEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpDelete]
        public override async Task<IspitObrisiResponse> Obradi([FromQuery] IspitObrisiRequest request)
        {

            var ispiti = _applicationDbContext.Ispit.FirstOrDefault(x => x.ID == request.IspitID);

            if (ispiti == null)
            {
                throw new Exception("nije pronadjen ispit za id = " + request.IspitID);
            }

            _applicationDbContext.Remove(ispiti);
            await _applicationDbContext.SaveChangesAsync();

            return new IspitObrisiResponse
            {
               
            };
        }
    }
}
