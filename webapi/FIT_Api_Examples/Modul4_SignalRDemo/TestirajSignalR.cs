using System.Collections.Generic;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Modul4_SignalRDemo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestirajSignalR : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHubContext<PorukeHub> _porukeHub;

        public TestirajSignalR(ApplicationDbContext dbContext, IHubContext <PorukeHub> porukeHub)
        {
            this._dbContext = dbContext;
            this._porukeHub = porukeHub;
        }

        [HttpGet]
        public async Task <ActionResult> PosaljiTrenutnoVrijeme()
        {
            var poruka = "Trenutno vrijeme : " + DateTime.Now.ToString("g");
            await _porukeHub.Clients.All.SendAsync("slanje_poruke1", poruka);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> PosaljiPoruku(string poruka)
        {
            await _porukeHub.Clients.All.SendAsync("slanje_poruke2", poruka);
            return Ok();
        }
    }
}
