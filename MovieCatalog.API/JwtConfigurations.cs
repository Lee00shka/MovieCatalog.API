using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MovieCatalog.API
{
    public class JwtConfigurations
    {
        public const string Issuer = "JwtIssuer";
        public const string Audience = "JwtClient"; 
        private const string Key = "SecretKey123123123123";   
        public const int Lifetime = 180; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
