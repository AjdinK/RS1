using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.Ispit.Dodaj
{
    [Route("ispit-dodaj")]
    public class IspitDodajEndpoint: MyBaseEndpoint<IspitDodajRequest,  IspitDodajResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public IspitDodajEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<IspitDodajResponse> Obradi([FromBody]IspitDodajRequest request)
        {
            var noviObj = new Data.Models.Ispit
            {
                PredmetID = request.PredmetId,
                DatumVrijemeIspita = request.Satnica,
                Komentar = request.Komentar
            };
            _applicationDbContext.Ispit.Add(noviObj);//

            await _applicationDbContext.SaveChangesAsync();//izvrašva se "insert into Ispit value ...."

            return new IspitDodajResponse
            {
                IspitId = noviObj.ID
            };
        }
    }
}
