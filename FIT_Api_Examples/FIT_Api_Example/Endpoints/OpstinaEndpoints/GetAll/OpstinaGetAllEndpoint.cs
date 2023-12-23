using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Example.Endpoints.OpstinaEndpoints.GetAll
{
    [Route("Opstina")]
    public class OpstinaGetAllEndpoint:MyBaseEndpoint<NoRequest,OpstinaGetAllResponse>
    {
        private readonly ApplicationDbContext _dbContext;

        public OpstinaGetAllEndpoint(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("get-all")]
        public override async Task <OpstinaGetAllResponse> Obradi ([FromQuery] NoRequest request, CancellationToken cancellationToken)
        {
            var opstine = await _dbContext.Opstina
                .OrderBy(o => o.ID)
                .Select(o => new OpstinaGetAllResponseOpstina (o.ID, o.drzava.Naziv + " " + o.description))
                .ToListAsync(cancellationToken: cancellationToken);

            return new OpstinaGetAllResponse (opstine);
        }
    }
}
