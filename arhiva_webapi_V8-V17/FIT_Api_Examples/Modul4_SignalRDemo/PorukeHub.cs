using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
namespace FIT_Api_Examples.Modul4_SignalRDemo
{
    public class PorukeHub : Hub
    {
        public async Task ProsljediPoruku(string poruka)
        {
            await Clients.Others.SendAsync("PosaljiPoruku", poruka);
        }
    }
}
