using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MovieCatalog.API.Services;
using Microsoft.AspNetCore.Authorization;
using MovieCatalog.API.Models.Views;

namespace MovieCatalog.API.Controllers
{
    [Route("api/account/profile")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private ISupportService _supportService;
        public UserController(IUserService userService, ISupportService supportService)
        {
            _userService=userService;
            _supportService=supportService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ProfileModel>> Get()
        {
            if (await _supportService.IsLogged(HttpContext.Request.Headers)) return BadRequest("The user is not authorized");
            var response = await _userService.Get(await _supportService.GetUserId(HttpContext.User));
            return Ok(response);
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(ProfileModel model)
        {
            if (await _supportService.IsLogged(HttpContext.Request.Headers)) return BadRequest("The user is not authorized");
            await _userService.Put(await _supportService.GetUserId(HttpContext.User), model);
            return Ok();
        }
    }
}
