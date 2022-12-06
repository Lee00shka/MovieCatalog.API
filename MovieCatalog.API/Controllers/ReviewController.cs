using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MovieCatalog.API.Services;
using MovieCatalog.API.Models.Views;
using Microsoft.AspNetCore.Authorization;

namespace MovieCatalog.API.Controllers
{
    [Route("api/movie/{movieId}/review/")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private IReviewService _reviewService;
        private ISupportService _supportService;
        public ReviewController(IReviewService reviewService, ISupportService supportService)
        {
            _reviewService=reviewService;
            _supportService=supportService;
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> Post(string movieId, ReviewModifyModel review)
        {
            if (await _supportService.IsLogged(HttpContext.Request.Headers)) return BadRequest("The user is not authorized");
            try
            {
                await _reviewService.Post
                    (movieId, await _supportService.GetUserId(HttpContext.User), review);
                return Ok();
            }   
            catch
            {
                return BadRequest("User have Review");
            }
        }
        [HttpPut("{id}/edit")]
        [Authorize]
        public async Task<IActionResult> Put(string id, ReviewModifyModel reviewModify)
        {
            if (await _supportService.IsLogged(HttpContext.Request.Headers)) return BadRequest("The user is not authorized");
            try
            {
                await _reviewService.Put
                    (await _supportService.GetUserId(HttpContext.User), id, reviewModify);
                return Ok();
            }
            catch
            {
                return BadRequest("User haven't right");
            }
        }
        [HttpDelete("{id}/delete")]
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            if (await _supportService.IsLogged(HttpContext.Request.Headers)) return BadRequest("The user is not authorized");
            try
            {
                await _reviewService.Delete(await _supportService.GetUserId(HttpContext.User), id);
                return Ok();
            }
            catch
            {
                return BadRequest("User haven't right");
            }
        }
    }
}
