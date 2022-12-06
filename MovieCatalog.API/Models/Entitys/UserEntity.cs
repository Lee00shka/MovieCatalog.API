using MovieCatalog.API.Models.Enum;

namespace MovieCatalog.API.Models.Entitys
{
    public class UserEntity
    {
        public string Id { get; set; }
        public string? NickName { get; set; }
        public string Email { get; set; }
        public string? AvatarLink { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }
        public string Password { get; set; }
        public List<MovieEntity> FavoriteMovies { get; set; }
    }
}
