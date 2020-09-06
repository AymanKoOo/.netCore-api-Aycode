using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AymanKoSolve.Hubs;
using AymanKoSolve.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AymanKoSolve.Controllers
{
    [Route("api/chat")]
    [ApiController]
    public class ChatController : ControllerBase
    {

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

        [Route("write")]                                           //path looks like this: https://localhost:44379/api/chat/send
        [HttpPost]
        public IActionResult WriteRequest([FromBody] MessageDto msg)
        {
            _hubContext.Clients.All.SendAsync("ReceiveText",msg.msgText);
            return Ok();
        }
    }
   
}
