using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AymanKoSolve.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AymanKoSolve.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _manager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserProfileController(ApplicationDbContext db, UserManager<ApplicationUser> manager,
            SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _manager = manager;
            _signInManager = signInManager;
        }
        [HttpGet]
        [Authorize]
        [Route("GetUserProfile")]
        public async Task<object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _manager.FindByIdAsync(userId);
            return new
            {
                user.UserName,
                user.Email,
            };
        }
    }
}