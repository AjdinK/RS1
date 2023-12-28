using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.Auth;

namespace FIT_Api_Example.Endpoints.StudentEndpoints.MaticnaKnjigaEndpoints.Dodaj;
    
    using Microsoft.AspNetCore.Mvc;


    [Route("student/maticna-knjiga")]
    [MyAuthorization]
    public class StudentMaticnaKnjigaDodajEndpoint : MyBaseEndpoint<StudentMaticnaKnjigaDodajRequest, NoResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _authService;
        public StudentMaticnaKnjigaDodajEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }

        [HttpPut()]
        public override async Task<NoResponse> Obradi([FromBody] StudentMaticnaKnjigaDodajRequest request, CancellationToken cancellationToken)
        {
            var noviZapis = new UpisAkGodine
            {
                AkademskaGodinaId = request.AkademskaGodinaID,
                CijenaSkolarine = request.CijenaSkolarine,
                Godinastudina = request.GodinaStudija,
                JelObnova = request.Obnova,
                DatumUpisZimski = request.ZimskiSemestarUpis,
                EvidentiraoKorisnikId = _authService.GetAuthInfo().korisnickiNalog!.ID,
                StudentId = request.StudentID
            };

            await _applicationDbContext.AddAsync(noviZapis, cancellationToken);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new NoResponse();
        }
    }
