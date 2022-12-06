using System.ComponentModel.DataAnnotations;

namespace MovieCatalog.API.Models.Views
{
    public class LoginCredentials
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
