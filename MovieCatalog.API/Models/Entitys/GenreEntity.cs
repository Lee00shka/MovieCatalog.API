namespace MovieCatalog.API.Models.Entitys
{
    public class GenreEntity
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public List<MovieEntity> Movies { get; set; }
    }
}
