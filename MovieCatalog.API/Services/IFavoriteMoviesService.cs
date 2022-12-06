using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCatalog.API.Models;
using MovieCatalog.API.Models.Views;
using MovieCatalog.API.Models.Entitys;

namespace MovieCatalog.API.Services
{
    public interface IFavoriteMoviesService
    {
        Task<MoviesListModel> Get(string userId);
        Task Post(string movieId, string userId);
        Task Delete(string movieId, string userId);
    }
    public class FavoriteMoviesService: IFavoriteMoviesService
    {
        private readonly Context _context;
        private ISupportService _supportService;
        public FavoriteMoviesService(Context context, ISupportService supportService)
        {
            _context=context;
            _supportService=supportService;
        }
        
        public async Task<MoviesListModel> Get(string userId)
        { 
            var user = _context.UserEntitys.
                Include(x => x.FavoriteMovies).ThenInclude(x=> x.Generes).
                FirstOrDefault(x => x.Id == userId);
            var movieList = user.FavoriteMovies.ToList();
            var movieElementModels = new List<MovieElementModel>();
            foreach (var movie in movieList)
            {
                movieElementModels.Add(await _supportService.GetMovieElement(movie));
            };
            return new MoviesListModel
            {
                Movies = movieElementModels
            };
        }
        public async Task Post(string movieId, string userId)
        {
            var user = _context.UserEntitys.Include(x=>x.FavoriteMovies).FirstOrDefault(x => x.Id == userId);
            var movie = _context.MovieEntitys.FirstOrDefault(x=> x.Id == movieId);
            if (user.FavoriteMovies.Any(x => x == movie)) throw new Exception();
            user.FavoriteMovies.Add(movie);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(string movieId, string userId)
        {
            var user = _context.UserEntitys.Include(x => x.FavoriteMovies).FirstOrDefault(x => x.Id == userId);
            var movie = _context.MovieEntitys.FirstOrDefault(x => x.Id == movieId);
            if (!user.FavoriteMovies.Any(x => x == movie)) throw new Exception();
            user.FavoriteMovies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
