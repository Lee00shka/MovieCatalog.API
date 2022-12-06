using Microsoft.AspNetCore.Http.Headers;
using System.Security.Claims;
using MovieCatalog.API.Models;
using MovieCatalog.API.Models.Entitys;
using MovieCatalog.API.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace MovieCatalog.API.Services
{
    public interface ISupportService
    {
        Task<string> GetToken(IHeaderDictionary headerDictionary);
        Task<string> GetUserId(ClaimsPrincipal principal);
        Task<bool> IsLogged(IHeaderDictionary headerDictionary);
        Task<MovieElementModel> GetMovieElement(MovieEntity movie);
    }
    public class SupportService : ISupportService
    {
        private readonly Context _context;
        public SupportService(Context context)
        {
            _context=context;
        }
        public async Task<string> GetToken(IHeaderDictionary headerDictionary)//HttpContext.Request.Headers
        {
            var requestHeaders = new Dictionary<string, string>();
            foreach (var header in headerDictionary)
            {
                requestHeaders.Add(header.Key, header.Value);
            }
            var autorizationSrting = requestHeaders["Authorization"];
            var token = autorizationSrting.Replace("Bearer ", "");
           return token;
        }

        public async Task<string> GetUserId(ClaimsPrincipal principal)//HttpContext.User
        {
            return principal.Claims.SingleOrDefault(p => p.Type==ClaimTypes.NameIdentifier).Value;
        }
        public async Task<bool> IsLogged(IHeaderDictionary headerDictionary)
        {
            var token = await GetToken(headerDictionary);
            var tokenEntity = _context.TokenEntitys.FirstOrDefault(x=> x.Token == token);
            return !(tokenEntity == null);
        }
        public async Task<MovieElementModel> GetMovieElement(MovieEntity movie)
        {
            var generes = movie.Generes.ToList();
            var genereModels = new List<GenereModel>();
            foreach (var genere in generes)
            {
                genereModels.Add(new GenereModel
                {
                    Id = genere.Id,
                    Name = genere.Name
                });
            }
            var reviewList = _context.ReviewEntitys.Where(x => x.Movie == movie).ToList();
            var reviewListModel = new List<ReviewShortModel>();
            foreach (var review in reviewList)
            {
                reviewListModel.Add(new ReviewShortModel
                {
                    Id = review.Id,
                    Rating = review.rating
                });
            }
            var movieElement = new MovieElementModel
            {
                Id=movie.Id,
                Name = movie.Name,
                Poster = movie.Poster,
                Year = movie.Year,
                Country = movie.Country,
                Genres = genereModels,
                Reviews = reviewListModel
            };
            return movieElement;
        }
    }
}
