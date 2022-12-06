using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MovieCatalog.API.Services;
using MovieCatalog.API.Models.Views;
using MovieCatalog.API.Models.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace MovieCatalog.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private ISupportService _supportService;
        public AuthController(IAuthService authService, ISupportService supportService)
        {
            _authService=authService;
            _supportService=supportService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            try
            {
                return await _authService.AddNewUser(model);
            }
            catch
            {
                return BadRequest("Еhis mail is already in use");
            }
        } 
        [HttpPost("login")]
        
        public async Task<IActionResult> Login(LoginCredentials model)
        {
            try
            {
                return await _authService.Login(model);
            }
            catch
            {
                return BadRequest("Invalid username or password");
            }
        }
        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            if (await _supportService.IsLogged(HttpContext.Request.Headers)) return BadRequest("The user is not authorized");
            var token = await _supportService.GetToken(HttpContext.Request.Headers);
            try
            { 
                return await _authService.Logout(token);
            }
            catch
            {
                return BadRequest("The user is not authorized");
            }
        }
    }
}
