using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.API.Models.Views
{
    public class ReviewModifyModel
    {
        [Required]
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public bool IsAnonymous { get; set; }
    }
}
