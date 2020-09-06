using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.Hubs
{
    public class ChatHub:Hub
    {
        public Task SendMessage1(string user, string message)// Two parameters accepted
        {
            return Clients.All.SendAsync("ReceiveOne", user, message);    // Note this 'ReceiveOne' 
        }
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "group1");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "group1");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task BroadcastText(string message)
        {
            await Clients.OthersInGroup("group1").SendAsync("ReceiveText", message);
        }
    }
}
