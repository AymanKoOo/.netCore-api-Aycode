using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AymanKoSolve.Models;
using AymanKoSolve.ModelViews.users;
using AymanKoSolve.repo.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AymanKoSolve.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class AdminController : ControllerBase
    {
        private IAdminRepo _rep;

        public AdminController(IAdminRepo repo)
        {
            _rep = repo;
        }
        [Route("AddNewUser")]
        [HttpPost]
        public async Task<IActionResult> AddNewUser(AddUserModel model)
        {
                var user = await _rep.AddNewUser(model);
                if (user != null) return Ok();
           
            return BadRequest();
        }


        [Route("EditUser")]
        [HttpGet]
        public async Task<ActionResult<ApplicationUser>> EditUser(string id)
        {
            if(id==null)return NotFound();
            var user = await _rep.EditUser(id);
            if (user != null) return user;

            return BadRequest();
        }

        [Route("EditUserTwo")]
        [HttpPut]
        public async Task<ActionResult<ApplicationUser>> EditUserTwo(editUserModel model)
        {
            
            var user = await _rep.EditUserTwo(model);
            if (user != null) return user;

            return BadRequest();
        }

        [Route("GetAllUseers")]
        [HttpGet]
        public async Task<IEnumerable<ApplicationUser>> GetAllUseers()
        {
            var users = await _rep.GetUsers();
            if (users == null)
            {
                return null;
            }
            return users;
        }
    }
}
