using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AymanKoSolve.Models;
using AymanKoSolve.ModelViews;
using AymanKoSolve.repo.email;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AymanKoSolve.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _db; //const intialize at compile time , readonly intialize at runtime
        private readonly UserManager<ApplicationUser> _manager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IEmail _em;

        public AccountController(IEmail em, ApplicationDbContext db, UserManager<ApplicationUser> manager,
            SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager )
        {
            _db = db;
            _manager = manager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _em = em;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(model == null)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {

                if (EmailExistes(model.Email))
                {
                    return BadRequest("Email is used");
                }

                if (UserNameExites(model.UserName))
                {

                    return BadRequest("User Name is used");
                }
                 
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName=model.UserName
                };
                var result = await _manager.CreateAsync(user,model.Password);
                if (result.Succeeded)
                {
                    var token = await _manager.GenerateEmailConfirmationTokenAsync(user);
                    //var confirmLink = Url.Action("RegisterationConfirm", "Account", new
                    //{ID = user.Id, Token = HttpUtility.UrlEncode(token)}, Request.Scheme);
                    //send email with link of controler + token
                    var encodeToken = Encoding.UTF8.GetBytes(token);
                    var newToken = WebEncoders.Base64UrlEncode(encodeToken);
                    var confirmLink = "http://localhost:8080/verify?ID=" + user.Id + "&Token=" + newToken;

                    try
                    {
                        _em.Send("mohamednaser9851@gmail.com", model.Email, "AyCode Verify", confirmLink);
                    }

                    catch (Exception e)
                    {
                        return BadRequest(result.Errors);
                    }


                    //when he click he goes to this controler and change to verfied
                    return Ok();
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        private bool UserNameExites(string userName)
        {
            return _db.Users.Any(x => x.UserName == userName);
        }

        private bool EmailExistes(string email)
        {
            return _db.Users.Any(x => x.Email == email);
        }



        [HttpGet("{id}")]
        [Authorize]
        public  ActionResult<string> RegisterationConfirm(int id)
        {
            var user = this.User;
            return "value";
        }


        [HttpGet]
        [Route("RegisterationConfirm")]
        public async Task<IActionResult> RegisterationConfirm(string ID,string Token)
        {
            if (string.IsNullOrEmpty(ID) || string.IsNullOrEmpty(Token)) return NotFound();
            
            var user = await _manager.FindByIdAsync(ID);
            if (user == null) return NotFound();

            var newToken = WebEncoders.Base64UrlDecode(Token);
            var encodeToken = Encoding.UTF8.GetString(newToken);

            var result = await _manager.ConfirmEmailAsync(user, encodeToken);

            if (result.Succeeded)
            {
                return StatusCode(StatusCodes.Status200OK);
                //Add email registeration //5
            }
            else
            {
                return BadRequest(result.Errors);
            }

        }


        //        [HttpPost]
        //        [Route("Login")]
        //        public async Task<IActionResult> Login(Login model)
        //        {
        //            await createRole();
        //            await CreateAddmin();
        //            if (model==null)return NotFound();

        //            var user = await _manager.FindByEmailAsync(model.email);

        //            if(user==null) return NotFound();

        //            var result = await _signInManager.PasswordSignInAsync(user, model.passowrd, model.RememberMe, true);

        //            if (result.Succeeded)
        //            {
        //                if (await _roleManager.RoleExistsAsync("User"))
        //                {
        //                    if(!await _manager.IsInRoleAsync(user, "User") && !await _manager.IsInRoleAsync(user, "Admin"))
        //                    {
        //                        await _manager.AddToRoleAsync(user, "User");
        //                    }
        //                }


        ////HttpContext is an object that wraps all http related information into one place. HttpContext.Current is a context that has been created during the active request. Here is the list of some data that you can obtain from it.

        ////    Request type (Post, Get)
        ////    Request parameters (querystring, posted data)
        ////    User's IP address
        ////    Cookies

        ////Further you can control your output through this object. In Items property, which is a dictionary, you can store instances of objects to ensure that they are created once for the request. You can control the output stream applying your custom filters.

        ////This is a short list of that what you can do with this property.

        //                var roleName = await GertRoleNameByUserId(user.Id);
        //                if (roleName != null)
        //                {
        //                    AddCookies(user.UserName, roleName, user.Id, model.RememberMe);

        //                }
        //                    return Ok();
        //            }
        //            else if (result.IsLockedOut)
        //            {
        //                return Unauthorized("User account is locked");
        //            }
        //            else
        //            {
        //                return BadRequest(result.IsNotAllowed);
        //            }
        //        }





        ////
        ///
        /// 
        /// 
   
     
        /// <summary>
        /// /
        /// </summary>
        ////// <returns></returns>

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Login model)
        {
            if (model == null) return NotFound();

            var user = await _manager.FindByEmailAsync(model.email);

            if (user != null && await _manager.CheckPasswordAsync(user,model.passowrd)) {

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                      new Claim("UserID",user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new {token});
            }

            else
            {
                return BadRequest(new { message = "Email or pwa is incorrect" });
            }
        }

        private async Task<string> GertRoleNameByUserId(string userId)
        {
            var userRole = await _db.UserRoles.FirstOrDefaultAsync(x => x.UserId == userId);
            if (userRole != null)
            {
                return await _db.Roles.Where(x => x.Id == userRole.RoleId).Select(x => x.Name).FirstOrDefaultAsync();
            }
            return null;
        }

        
        [HttpGet]
        [Authorize]
        [Route("GetAllusers")]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> allUsers()
        {
            return await _db.Users.ToListAsync();
        }

        [HttpPost]
        [Route("UserNameExist")]
        public async Task<bool> UserNameExist(string userName)
        {
            var x = _db.Users.Any(x => x.UserName == userName); 
            return x;
        }

        private async Task CreateAddmin()
        {
           var admin = await _manager.FindByNameAsync("Admin");
            if (admin == null)
            {
                var user = new ApplicationUser
                {
                    Email = "admin@gmail.com",
                    UserName = "Admin",
                    EmailConfirmed = true
                };
               var x = await _manager.CreateAsync(user, "123#Aa");
                if (x.Succeeded)
                {
                    if(await _roleManager.RoleExistsAsync("Admin"))
                      await _manager.AddToRoleAsync(user, "Admin");
                }
            }
        }

        private async Task createRole()
        {
            if (_roleManager.Roles.Count() < 1)
            {
                var role = new ApplicationRole
                {
                    Name = "Admin"
                };
                await _roleManager.CreateAsync(role);

                role = new ApplicationRole
                {
                    Name = "User"
                };
                await _roleManager.CreateAsync(role);
            }
        }

        public async void AddCookies(string username,string roleName,string userId, bool remeber)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Role, roleName),
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            if (remeber)
            {
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh=true,
                    IsPersistent=remeber,
                    ExpiresUtc = DateTime.UtcNow.AddDays(10)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
            }
            else
            {
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = remeber,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
            }
        }
        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }


        [HttpGet]
        [Route("GetRoleName/{email}")]
        public async Task<string> GetRoleName(string email)
        {
            var user = await _manager.FindByEmailAsync(email);
            if (user != null)
            {
                var userRole = await _db.UserRoles.FirstOrDefaultAsync(x => x.UserId == user.Id);
                if (userRole != null)
                {
                    return await _db.Roles.Where(x => x.Id == userRole.RoleId).Select(x => x.Name).FirstOrDefaultAsync();
                }
            }
            return null;
        }


        [HttpGet]
        [Route("CheckUserClaims/{email}&{role}")]
        public IActionResult CheckUserClaims(string email, string role)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userEmail != null && userRole != null && id != null)
            {
                if (email == userEmail && role == userRole)
                {
                     return  StatusCode(StatusCodes.Status200OK);
                }

            }
            return StatusCode(StatusCodes.Status203NonAuthoritative);
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("IsUserNameExist/{userName}")]
        public async Task<IActionResult> IsUserNameExist(string userName)
        { 
            var x = await  _db.Users.AnyAsync(x => x.UserName == userName);

            if (x)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("IsEmailExist/{email}")]
        public async Task<IActionResult> IsEmailExist(string email)
        {
            var x = await _db.Users.AnyAsync(x => x.Email == email);

            if (x)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        //[HttpGet]
        //[Route("IsEmailExist/{email}")]
        //public IActionResult IsEmailExist(string email)
        //{




        //}
    }
}