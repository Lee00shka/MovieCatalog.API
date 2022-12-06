using MovieCatalog.API.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.API.Models.Views
{
    public class UserRegisterModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }

    }
}
