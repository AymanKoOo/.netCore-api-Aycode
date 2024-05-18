using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AymanKoSolve.Models;
using AymanKoSolve.repo.Chat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AymanKoSolve.Controllers
{
    [Route("api/RealTime")]
    [ApiController]
    [Authorize]
    public class RealTimeController : ControllerBase
    {

        private IChatRepo _repo;

        public RealTimeController(IChatRepo repo)
        {
            _repo = repo;
        }


        [Route("getRoom")]
        [HttpGet]
        public async Task<Chatt> GetChat(int id)
        {
             var result = await _repo.GetChat(id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        

        [Route("CreateMessage")]
        [HttpPost]
        public async Task<IActionResult> CreateMessage(int roomId,string message)
        {
            var result = await _repo.CreateMessage(roomId,message);
            if (result != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("createRoom")]
        [HttpPost]
        public async Task<IActionResult> CreateRoomm(string name)
        {
            var currentUser = HttpContext.User;
            string id = currentUser.FindFirst("UserID").Value;

            var result = await _repo.CreateRoom(name,id);
            if (result != null)
            {
               return Ok();
            }
            return BadRequest();
        }

        [Route("joinRoom")]
        [HttpPost]
        public async Task<IActionResult> joinRoomm(int roomId)
        {
            var currentUser = HttpContext.User;
            string id = currentUser.FindFirst("UserID").Value;

            var result = await _repo.joinRoom(roomId, id);
            if (result != null)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}