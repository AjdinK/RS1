using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.Ispit.Update
{
    [Route("ispit-update")]
    public class IspitUpdateEndpoint: MyBaseEndpoint<IspitUpdateRequest,  IspitUpdateResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public IspitUpdateEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<IspitUpdateResponse> Obradi([FromBody] IspitUpdateRequest request)
        {
            var ispiti = _applicationDbContext.Ispit.FirstOrDefault(x => x.ID == request.Id);

            if (ispiti == null)
            {
                throw new Exception("nije pronadjen ispit za id = " + request.Id);
            }

            ispiti.Komentar = request.Komentar;
            ispiti.DatumVrijemeIspita = request.Satnica;

            await _applicationDbContext.SaveChangesAsync();//izvrašva se "insert into Ispit value ...."

            return new IspitUpdateResponse
            {
                IspitId = ispiti.ID
            };
        }
    }
}
