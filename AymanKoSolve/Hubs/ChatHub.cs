using AymanKoSolve.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AymanKoSolve.Hubs
{
    public class ChatHub:Hub
    {
      
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        /////Code Editor/////
       

        public Task codeEditor(string msg)
        {
            return Clients.All.SendAsync("ReceiveText", msg);
        }


        /// Send Message to All
        public Task SendMessageToAll(string msg)
        {
            return Clients.All.SendAsync("ReceiveText", msg);
        }

        // Send Message to specific user using  connection ID
        public Task SendMessageToUser(string connectionId, string msg)
        {
            //text = text + msg.msgText;
            return Clients.Client(connectionId).SendAsync("ReceiveText", msg);
        }

        public Task joingroup(string group)
        {
           return  Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public Task SendMessageToGroup(string group, string message)
        {
            return Clients.Group(group).SendAsync("ReceiveText", message);       
        }

    }
}
