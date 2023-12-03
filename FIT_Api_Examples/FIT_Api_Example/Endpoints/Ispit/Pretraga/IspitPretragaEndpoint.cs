using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.Ispit.Pretraga
{
    [Route("ispit-pretraga")]
    public class IspitPretragaEndpoint: MyBaseEndpoint<IspitPretragaRequest,  IspitPretragaResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public IspitPretragaEndpoint(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public override async Task<IspitPretragaResponse> Obradi([FromQuery] IspitPretragaRequest request)
        {
            var ispiti = await _applicationDbContext
                .Ispit
                .Where(x => request.Naziv == null || x.Predmet.Naziv.ToLower().StartsWith(request.Naziv.ToLower()))
                .Select(x => new IspitPretragaResponseIspit()
                {
                    IdIspita = x.ID,
                    Komnt = x.Komentar,
                    Satnica = x.DatumVrijemeIspita,
                    PredmetId = x.PredmetID,
                    PuniNaziv = x.Predmet.Naziv,
                    SifraPredmeta = x.Predmet.Sifra,
                    Bodovi = x.Predmet.Ects
                }).ToListAsync();

            return new IspitPretragaResponse
            {
               Ispiti = ispiti
            };
        }
    }
}
