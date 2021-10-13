using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Chat.API.Infrastructure.Hubs
{
    [Authorize]
    public class ChatHub: Hub
    {
   

        public Task SendMessageToUser(string userId, string message)
        {
            return Clients.User(userId).SendAsync("ReceiveMessage", message);
        }

        public Task SendMessageToGroup(string message)
        {
            return Groups.AddToGroupAsync("ReceiveMessage", message);
        }

    }
}
