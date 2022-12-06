
namespace MovieCatalog.API.Models.Entitys
{
    public class ReviewEntity
    {
        public string Id { get; set; }
        public int  rating { get; set; }
        public string? ReviewText { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime CreateDateTime { get; set; }
        public MovieEntity Movie { get; set; }
        public UserEntity Autor { get; set; }
    }
}
