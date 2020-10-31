using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AymanKoSolve.Models;
using AymanKoSolve.ModelViews.problem;
using AymanKoSolve.ModelViews.users;
using AymanKoSolve.repo.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AymanKoSolve.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [Route("DeleteUser")]
        [HttpPost]
        public async Task<ActionResult> DeleteUser(string id)
        {
            if (id == null) return NotFound();
            var check = await _rep.DeleteUser(id);
            if (check==true)
            {
                return Ok();
            }
            return BadRequest();
        }

        
        [Route("DeleteprobSource")]
        [HttpPost]
        public async Task<ActionResult> DeleteprobSource(int id)
        {
            if (id < 0) return NotFound();
            var check = await _rep.DeleteprobSource(id);
            if (check == true)
            {
                return Ok();
            }
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
        //////////////////////////////
        [Route("AddprobSource")]
        [HttpPost]
        public async Task<ActionResult> AddprobSource(addProblemSource model)
        {
            if (model == null) return NotFound();
            var result = await _rep.AddprobSource(model);
         
            if (result!=null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("EditprobSource")]
        [HttpPut]
        public async Task<ActionResult> EditprobSource(addProblemSource model)
        {
            if (model == null) return BadRequest();
            var result = await _rep.EditprobSource(model);
            if (result != null) return Ok();

            return BadRequest();
        }

        [Route("GetAllprobSource")]
        [HttpGet]
        public async Task<object> GetAllprobSource()
        {
            var sources = await _rep.GetAllprobSource();
            if (sources == null)
            {
                return null;
            }
            return sources;
        }


        [Route("GetprobSource")]
        [HttpPost]
        public async Task<problemSource> GetprobSource(int sourceId)
        {
            var sources = await _rep.GetprobSource(sourceId);
            if (sources == null)
            {
                return null;
            }
            return sources;
        }

        //////////////////////////////////
        [Route("AddprobType")]
        [HttpPost]
        public async Task<ActionResult> AddprobType(problemType model)
        {
            if (model == null) return NotFound();
            var result = await _rep.AddprobType(model);

            if (result != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("EditprobType")]
        [HttpPut]
        public async Task<ActionResult> EditprobType(problemType model)
        {
            if (model == null) return BadRequest();
            var result = await _rep.EditprobType(model);
            if (result != null) return Ok();

            return BadRequest();
        }


        [Route("GetAllprobType")]
        [HttpGet]
        public async Task<IEnumerable<problemType>> GetAllprobType()
        {
            var sources = await _rep.GetAllprobType();
            if (sources == null)
            {
                return null;
            }
            return sources;
        }


        [Route("GetprobType")]
        [HttpPost]
        public async Task<problemType> GetprobType(int id)
        {
            var sources = await _rep.GetprobType(id);
            if (sources == null)
            {
                return null;
            }
            return sources;
        }

        [Route("DeleteprobType")]
        [HttpPost]
        public async Task<ActionResult> DeleteprobType(int id)
        {
            if (id < 0) return NotFound();
            var check = await _rep.DeleteprobType(id);
            if (check == true)
            {
                return Ok();
            }
            return BadRequest();
        }


        //////////////////////////////////
        [Route("AddprobHeader")]
        [HttpPost]
        public async Task<ActionResult> AddprobHeader([FromBody] addProblemHeader model)
        {
            if (model == null) return NotFound();
            var result = await _rep.AddprobHeader(model);

            if (result != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("EditprobHeader")]
        [HttpPut]
        public async Task<ActionResult> EditprobHeader(problemHeader model)
        {
            if (model == null) return BadRequest();
            var result = await _rep.EditprobHeader(model);
            if (result != null) return Ok();

            return BadRequest();
        }


        [Route("GetAllprobHeader")]
        [HttpGet]
        public async Task<object> GetAllprobHeader()
        {
            var sources = await _rep.GetAllprobHeader();
            if (sources == null)
            {
                return null;
            }
            return sources;
        }


        [Route("GetprobHeader")]
        [HttpPost] 
        public async Task<object> GetprobHeader(int id)
        {
            var sources = await _rep.GetprobHeader(id);
            if (sources == null)
            {
                return null;
            }
            return sources;
        }

        [Route("DeleteprobHeadr")]
        [HttpPost]
        public async Task<ActionResult> DeleteprobHeadr(int id)
        {
            if (id < 0) return NotFound();
            var check = await _rep.DeleteprobHeader(id);
            if (check == true)
            {
                return Ok();
            }
            return BadRequest();
        }


        ///////////////////////////////////////
        /// //////////////////////////////////
        [Route("Addprobcontent")]
        [HttpPost]
        public async Task<ActionResult> Addprobcontent([FromBody] problemContent model)
        {
            if (model == null) return NotFound();
            var result = await _rep.Addprobcontent(model);

            if (result != null)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Route("GetAllprobcontent")]
        [HttpGet]
        public async Task<object> GetAllprobcontent()
        {
            var sources = await _rep.GetAllprobcontent();
            if (sources == null)
            {
                return null;
            }
            return sources;
        }


        [Route("Getprobcontent")]
        [HttpPost]
        public async Task<object> Getprobcontent(int id)
        {
            var sources = await _rep.Getprobcontent(id);
            if (sources == null)
            {
                return null;
            }
            return sources;
        }

        [Route("GetprobcontentbyName")]
        [HttpPost]
        public async Task<object> GetprobcontentbyName(string probName)
        {
            var sources = await _rep.GetprobcontentbyName(probName);
            if (sources == null)
            {
                return null;
            }
            return sources;
        }

        [Route("Deleteprobcontent")]
        [HttpPost]
        public async Task<ActionResult> Deleteprobcontent(int id)
        {
            if (id < 0) return NotFound();
            var check = await _rep.Deleteprobcontent(id);
            if (check == true)
            {
                return Ok();
            }
            return BadRequest();
        }



        [Route("GetprobHeaderJ")]
        [HttpPost]
        public async Task<object> GetprobHeaderJ(string probType,string probSource)
        {
            var sources = await _rep.GetprobHeaderJ(probType,probSource);
            if (sources == null)
            {
                return null;
            }
            return sources;
        }

        [Route("GetprobContentJ")]
        [HttpPost]
        public async Task<object> GetprobContentJ(string probType)
        {
            var sources = await _rep.GetprobContentJ(probType);
            if (sources == null)
            {
                return null;
            }
            return sources;
        }

        [AllowAnonymous]
        [Route("IsAdmin")]
        [HttpGet]
        public bool IsAdmin()
        {
            var currentUser = HttpContext.User;
            string UserID="";
     
            if (currentUser.HasClaim(c => c.Type == "UserID"))
            {
                 UserID = currentUser.Claims.FirstOrDefault(c => c.Type == "UserID").Value;
            }

            string UserRoleName = _rep.GetUserRole(UserID);

            if (UserRoleName == "Admin") return true;
            else return false;
        }


        
        [Route("GetAllUserData")]
        [HttpGet]
        public async Task<object> GetAllUserData()
        {
            var currentUser = HttpContext.User;
            string UserID = "";

            if (currentUser.HasClaim(c => c.Type == "UserID"))
            {
                UserID = currentUser.Claims.FirstOrDefault(c => c.Type == "UserID").Value;
            }

            var user =await _rep.GetAllUserData(UserID);

            if (user == null) return null;
            return user;
        }


    }
}
