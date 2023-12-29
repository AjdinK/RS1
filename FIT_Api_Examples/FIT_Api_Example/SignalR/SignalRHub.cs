using Microsoft.AspNetCore.SignalR;

namespace FIT_Api_Example.SignalR
{
    public class SignalRHub:Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine(this.Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
