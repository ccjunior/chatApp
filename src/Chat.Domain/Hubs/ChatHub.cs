using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Hubs
{
    public class ChatHub : Hub
    {
        public Task JoinRoom(string roomId)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }

        public Task LeaveRoom(string roomId)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);
        }
    }
}
