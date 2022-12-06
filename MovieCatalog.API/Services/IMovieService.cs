using MovieCatalog.API.Models.Views;
using MovieCatalog.API.Models;
using MovieCatalog.API.Models.Entitys;
using System.Collections.Immutable;
using MovieCatalog.API.Models.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace MovieCatalog.API.Services
{
    public interface IMovieService
    {
        Task<MoviesPagedListModel> GetPage(int page);
        Task<MovieDetailsModel> GetMovieDetails(string id);
    }
    public class MovieService : IMovieService
    {
        private readonly Context _context;
        private ISupportService _supportService;
        private int _pageSize = 2;
        private int _pageCount = 2;
        public MovieService(Context context, ISupportService supportService)
        {
            _context=context;
            _supportService=supportService;
        }
        public async Task<MoviesPagedListModel> GetPage(int page)
        {
            var movieEntitys = _context.MovieEntitys.Include(x => x.Generes).ToList();
            var pageInfo = new PageInfoModel
            {
                PageCount = _pageCount,
                PageSize = _pageSize,
                CurrentPage = page
            };
            var movieElements = new List<MovieElementModel>();
            int i = 1;
            int movieCount = movieEntitys.Count();
            foreach (var movie in movieEntitys)
            {
                if (i > _pageSize*(page-1) && i <= _pageSize*page)
                movieElements.Add(await _supportService.GetMovieElement(movie));
                i++;
            }
            return new MoviesPagedListModel
            {
                Movies = movieElements,
                PageInfo = pageInfo
            };
        }
        public async Task<MovieDetailsModel> GetMovieDetails(string id)
        {
            var movie = _context.MovieEntitys
                .Include(x => x.Generes)
                .FirstOrDefault(x => x.Id == id);
            if (movie == null) throw new Exception();
            var movieElement = await _supportService.GetMovieElement(movie);
            var reviewList = _context.ReviewEntitys
                .Include(x => x.Autor)
                .Where(x => x.Movie == movie).ToList();
            var reviewListModel = new List<ReviewModel>();
            foreach (var review in reviewList)
            {
                var autor = new UserShortModel
                {
                    UserId = review.Autor.Id,
                    NickName = review.Autor.NickName,
                    Avatar = review.Autor.AvatarLink
                };
                reviewListModel.Add(new ReviewModel
                {
                    Id = review.Id,
                    Rating = review.rating,
                    ReviewText = review.ReviewText,
                    IsAnonymous = review.IsAnonymous,
                    CreateDateTime = review.CreateDateTime,
                    autor = autor
                });
            }
            var movieDetailsModel = new MovieDetailsModel { 
                Id = movie.Id,
                Name = movie.Name,
                Poster = movie.Poster,
                Year = movie.Year,
                Country = movie.Country,
                Generes = movieElement.Genres,
                Reviews = reviewListModel,
                Time = movie.Time,
                Tagline = movie.Tagline,
                Description = movie.Description,
                Director = movie.Director,
                Budget = movie.Budget,
                Fees = movie.Fees,
                AgeLimit = movie.AgeLimit
            };
            return movieDetailsModel;
        }
    }
}
