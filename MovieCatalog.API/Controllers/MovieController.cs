using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MovieCatalog.API.Services;
using MovieCatalog.API.Models.Views;
using MovieCatalog.API.Models.Entitys;

namespace MovieCatalog.API.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService=movieService;
        }
        [HttpGet("{page}")]
        public async Task<MoviesPagedListModel> GetPage(int page = 1)
        {
            var response = await _movieService.GetPage(page);
            return response;
        }
        [HttpGet("details/{id}")]
        public async Task<MovieDetailsModel> GetDetails(string id)
        {
            return await _movieService.GetMovieDetails(id);
        }
    }
}
