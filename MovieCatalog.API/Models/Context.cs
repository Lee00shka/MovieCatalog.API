using Microsoft.EntityFrameworkCore;
using MovieCatalog.API.Models.Entitys;

namespace MovieCatalog.API.Models
{
    public class Context : DbContext
    {
        public DbSet<UserEntity> UserEntitys { get; set; }
        public DbSet<GenreEntity> GenreEntitys { get; set; }
        public DbSet<MovieEntity> MovieEntitys { get; set; }
        public DbSet<ReviewEntity> ReviewEntitys { get; set; }
        public DbSet<TokenEntity> TokenEntitys { get; set; }

        public Context(DbContextOptions<Context> options): base(options)
        {
            Database.EnsureCreated();
        }

    }
}
