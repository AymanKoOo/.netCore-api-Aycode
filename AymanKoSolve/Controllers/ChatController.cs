using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AymanKoSolve.Hubs;
using AymanKoSolve.Models;
using AymanKoSolve.repo.Chat;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AymanKoSolve.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase 
    {

        public string text = "";
        private readonly IHubContext<ChatHub> _hubContext;
       
        public ChatController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [Route("send")]                                           //path looks like this: https://localhost:44379/api/chat/send
        [HttpPost]
        public IActionResult SendRequest([FromBody] MessageDto msg)
        {
            _hubContext.Clients.All.SendAsync("ReceiveOne", msg.user, msg.msgText);
            return Ok();
        }

        //[Route("SendMessageToAll")]                                           //path looks like this: https://localhost:44379/api/chat/send
        //[HttpPost]
        //public IActionResult SendMessageToAll([FromBody] MessageDto msg)
        //{
        //    text = text + msg.msgText;
        //    _hubContext.Clients.All.SendAsync("ReceiveText", text);

        //    return Ok();
        //}

        //[Route("SendMessageToUser")]                                           //path looks like this: https://localhost:44379/api/chat/send
        //[HttpPost]
        //public IActionResult SendMessageToUser(string connectionId,string msg)
        //{
        //    //text = text + msg.msgText;
        //    _hubContext.Clients.Client(connectionId).SendAsync("ReceiveText", msg);
        //    return Ok();
        //}

        //[Route("codeEditor")]                                           //path looks like this: https://localhost:44379/api/chat/send
        //[HttpPost]
        //public IActionResult codeEditor([FromBody] MessageDto msg)
        //{
        //    text = text + msg.msgText;
        //    _hubContext.Clients.All.SendAsync("ReceiveText", text);

        //    return Ok();
        //}

        //[Route("GetConnectionId")]                                           //path looks like this: https://localhost:44379/api/chat/send
        //[HttpGet]
        //public string GetConnectionId()
        //{
        //    ChatHub ob1 = new ChatHub();
        //    string id = ob1.GetConnectionId();
        //    return id;
        //}
        //[Route("JoinGroup")]                                           //path looks like this: https://localhost:44379/api/chat/send
        //[HttpPost]
        //public  IActionResult JoinGroup(string group)
        //{
        //    ChatHub ob1 = new ChatHub();
        //    ob1.joingroup(group);
        //    return Ok();
        //}

        //[Route("SendMessageToGroup")]                                           //path looks like this: https://localhost:44379/api/chat/send
        //[HttpPost]
        //public IActionResult SendMessageToGroup(string group,string message)
        //{
        //    _hubContext.Clients.Group(group).SendAsync("ReveiveMessage", message);
        //    return Ok();
        //}
        //////
        ///
        //[Route("JoinRoom")]                                           //path looks like this: https://localhost:44379/api/chat/send
        //[HttpPost]
        //public async Task<IActionResult> JoinRoom(string connectionId, string roomName)
        //{
        //    await _hubContext.Groups.AddToGroupAsync(, roomName);
        //    return Ok();
        //}
        //////
        [Route("LeaveRoom")]                                           //path looks like this: https://localhost:44379/api/chat/send
        [HttpPost]
        public async Task<IActionResult> LeaveRoom(string connectionId, string roomName)
        {
            await _hubContext.Groups.RemoveFromGroupAsync(connectionId, roomName);
            return Ok();
        }
        /////
        ///
        [Route("SendMessage")]                                           //path looks like this: https://localhost:44379/api/chat/send
        [HttpPost]
        public async Task<IActionResult> SendMessage(int chatId,string message, string roomName,[FromServices]ApplicationDbContext _db)
        {
            var messagee = new Message
            {

                Name = "Default",
                Text = message,
                ChatId = chatId,
                Timestamp = DateTime.Now
            };

            var result = _db.Message.AddAsync(messagee);
            await _db.SaveChangesAsync();
          
            await _hubContext.Clients.Group(roomName).SendAsync("RecivedMesage", new
            {
                Name = messagee.Name,
                Text = messagee.Text,
                Timestamp = DateTime.Now
            }); 
            return Ok();
        }

    }
}
