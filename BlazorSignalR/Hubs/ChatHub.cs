using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task ServerReceiveMessage(string user, string message)
        {
            await Clients.All.SendAsync("ClientReceiveMessage", user + $" => {Context.ConnectionId}", message); // events
        }

        public async Task KickServerReceiveMessage(string connectionId)
        {
            await Clients.Client(connectionId).SendAsync("KickClientReceiveMessage"); // events
        }
    }
}
