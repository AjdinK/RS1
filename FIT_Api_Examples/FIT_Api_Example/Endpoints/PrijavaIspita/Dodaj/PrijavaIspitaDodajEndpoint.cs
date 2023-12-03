using FIT_Api_Example.Data;
using FIT_Api_Example.Endpoints.Ispit.Dodaj;
using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.PrijavaIspita.Dodaj
{
    [Route("prijava-ispit-dodaj")]
    public class PrijavaIspitaDodajEndpoint: MyBaseEndpoint<PrijavaIspitaDodajRequest,  PrijavaIspitaDodajResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PrijavaIspitaDodajEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpPost]
        public override async Task<PrijavaIspitaDodajResponse> Obradi([FromBody] PrijavaIspitaDodajRequest request)
        {
            var noviObj = new Data.Models.PrijavaIspita
            {
             DatumPrijave = DateTime.Now,
              IspitID = request.IspitId,
              StudentID = request.StudentId
            };
            _applicationDbContext.Add(noviObj);//

            await _applicationDbContext.SaveChangesAsync();//izvrašva se "insert into Ispit value ...."

            return new PrijavaIspitaDodajResponse
            {
               PrijavaIspitId = noviObj.ID
            };
        }
    }
}
