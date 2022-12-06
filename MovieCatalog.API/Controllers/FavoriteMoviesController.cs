using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MovieCatalog.API.Services;
using Microsoft.AspNetCore.Authorization;
using MovieCatalog.API.Models.Views;

namespace MovieCatalog.API.Controllers
{
    [Route("api/favorites")]
    [ApiController]
    public class FavoriteMoviesController : ControllerBase
    {
        private IFavoriteMoviesService _favoriteMoviesService;
        private ISupportService _supportService;
        public FavoriteMoviesController(IFavoriteMoviesService favoriteMoviesService, ISupportService supportService)
        {
            _favoriteMoviesService=favoriteMoviesService;
            _supportService=supportService;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<MoviesListModel>> Get()
        {
            if (await _supportService.IsLogged(HttpContext.Request.Headers)) return BadRequest("The user is not authorized");
            return Ok(await _favoriteMoviesService.Get(await _supportService.GetUserId(HttpContext.User))); ;
        }

        [HttpPost("{id}/add")]
        [Authorize]
        public async Task<IActionResult> Post(string id)
        {
            if (await _supportService.IsLogged(HttpContext.Request.Headers)) return BadRequest("The user is not authorized");
            try
            {
                await _favoriteMoviesService.Post(id, await _supportService.GetUserId(HttpContext.User));
                return Ok();
            }
            catch
            {
                return BadRequest("The movie has already been added to favorites");
            }
        }
        [HttpDelete("{id}/delete")]
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            if (await _supportService.IsLogged(HttpContext.Request.Headers)) return BadRequest("The user is not logged");
            try
            {
                await _favoriteMoviesService.Delete(id, await _supportService.GetUserId(HttpContext.User));
                return Ok();
            }
            catch
            {
                return BadRequest("The movie was not added to favorites");
            }
        }
    }
}
