using MovieCatalog.API.Models.Entitys;
using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.API.Models.Views
{
    public class MovieElementModel
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Poster { get; set; }
        public int Year { get; set; }
        public string? Country { get; set; }
        public List<GenereModel> Genres { get; set; }
        public List<ReviewShortModel> Reviews { get; set; }
    }
}
