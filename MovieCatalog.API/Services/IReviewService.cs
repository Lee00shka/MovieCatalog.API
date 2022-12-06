using MovieCatalog.API.Models;
using MovieCatalog.API.Models.Views;
using MovieCatalog.API.Models.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace MovieCatalog.API.Services
{
    public interface IReviewService
    {
        Task Post(string movieId, string userId, ReviewModifyModel review);
        Task Put(string userId, string reviewId, ReviewModifyModel reviewModify);
        Task Delete(string userId, string reviewId);
    }

    public class ReviewService: IReviewService
    {
        private readonly Context _context;
        public ReviewService(Context context)
        {
            _context=context;
        }

        public async Task Post(string movieId, string userId, ReviewModifyModel review)
        {
            var user = _context.UserEntitys.FirstOrDefault(x => x.Id == userId);
            var movie = _context.MovieEntitys.FirstOrDefault(x => x.Id == movieId);
            var check = _context.ReviewEntitys.FirstOrDefault(x => x.Movie == movie && x.Autor == user);
            if (check != null) throw new Exception();
            var id = Guid.NewGuid().ToString();
            await _context.ReviewEntitys.AddAsync(new ReviewEntity
            {
                Id = id,
                rating = review.Rating,
                ReviewText = review.ReviewText,
                IsAnonymous = review.IsAnonymous,
                CreateDateTime = DateTime.Now,
                Movie = movie,
                Autor = user
            });
            await _context.SaveChangesAsync();
        }
        public async Task Put(string userId, string reviewId, ReviewModifyModel reviewModify)
        {
            var user = await _context.UserEntitys.FirstOrDefaultAsync(x => x.Id == userId);
            var review = _context.ReviewEntitys.FirstOrDefault(x => x.Id == reviewId && x.Autor == user);
            if (review == null) throw new Exception();
            review.ReviewText = reviewModify.ReviewText;
            review.rating = reviewModify.Rating;
            review.IsAnonymous = reviewModify.IsAnonymous;
            _context.ReviewEntitys.Update(review);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(string userId, string reviewId)
        {
            var user = await _context.UserEntitys.FirstOrDefaultAsync(x => x.Id == userId);
            var review = _context.ReviewEntitys.FirstOrDefault(x=>x.Id == reviewId && x.Autor == user);
            if (review == null) throw new Exception();
            _context.ReviewEntitys.Remove(review);
            await _context.SaveChangesAsync();
        }
    }
}
