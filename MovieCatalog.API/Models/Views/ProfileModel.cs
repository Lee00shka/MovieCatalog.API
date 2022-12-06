using MovieCatalog.API.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MovieCatalog.API.Models.Views
{
    public class ProfileModel
    {
        public string Id { get; set; }
        public string? NickName { get; set; }
        [Required]
        public string Email { get; set; }
        public string? AvatarLink { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }

    }
}
