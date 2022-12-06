namespace MovieCatalog.API.Models.Views
{
    public class ReviewModel
    {
        public string Id { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime CreateDateTime { get; set; }
        public UserShortModel autor { get; set; }
    }
}
