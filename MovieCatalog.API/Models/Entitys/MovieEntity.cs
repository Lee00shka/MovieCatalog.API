

namespace MovieCatalog.API.Models.Entitys
{
    public class MovieEntity
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Poster { get; set; }
        public int Year { get; set; }
        public string? Country { get; set; }
        public List<GenreEntity>? Generes { get; set; }
        public int Time { get; set; }
        public string? Tagline { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public int? Budget { get; set; }
        public int? Fees { get; set; }
        public int? AgeLimit { get; set; }
        public List<UserEntity>? UsersFavorite { get; set; }
    }
}
