using MovieCatalog.API.Models;
using MovieCatalog.API.Models.Views;
using MovieCatalog.API.Models.Entitys;
using MovieCatalog.API;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace MovieCatalog.API.Services
{
    public interface IAuthService
    {
        Task<IActionResult> AddNewUser(UserRegisterModel model);
        Task<IActionResult> Login(LoginCredentials model);
        Task<IActionResult> Logout(string token);
    }
    public class AuthService : IAuthService
    {
        private readonly Context _context;
        public AuthService(Context context)
        {
            _context=context;
        }
        
        private ClaimsIdentity GetIdentity(string username, string id)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.NameId, id),
            };
            ClaimsIdentity claimidentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, 
            ClaimTypes.NameIdentifier);
            return claimidentity;
        }
        private JwtSecurityToken GenerateJWT(string username, string id)
        {
            var now = DateTime.UtcNow;
            var identity = GetIdentity(username, id);
            var jwt = new JwtSecurityToken(
                issuer: JwtConfigurations.Issuer,
                audience: JwtConfigurations.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.AddMinutes(JwtConfigurations.Lifetime),
                signingCredentials: new SigningCredentials(JwtConfigurations.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return jwt;
        }

        public async Task<IActionResult> AddNewUser(UserRegisterModel model)
        { 
            var check = _context.UserEntitys.FirstOrDefault(x=> x.Email == model.Email);
            if (check != null) throw new Exception(); 
            var id = Guid.NewGuid().ToString();
            await _context.UserEntitys.AddAsync(new UserEntity
            {
                Id = id,
                NickName = model.UserName,
                Name = model.Name,
                Password = model.Password,
                Email = model.Email,
                BirthDate = model.BirthDate,
                Gender = model.Gender
            });

            var jwt = GenerateJWT(model.UserName, id);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new
            {
                token = encodedJwt
            };
            await _context.SaveChangesAsync();
            return new JsonResult(response);
        }
        public async Task<IActionResult> Login(LoginCredentials model)
        {
            var user = _context.UserEntitys.FirstOrDefault(x=> x.NickName == model.Username && x.Password == model.Password);
            if (user == null)
            {
                throw new Exception();
            }
            var jwt = GenerateJWT(model.Username, user.Id);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new
            {
                token = encodedJwt
            };
            return new JsonResult(response);
        }
        public async Task<IActionResult> Logout(string token)
        { 
            var id = Guid.NewGuid().ToString();
            await _context.TokenEntitys.AddAsync(new TokenEntity
            {
                Id = id,
                Token = token
            });
            await _context.SaveChangesAsync();

            var response = new
            {
                
                token = "",
                message = "Logged Out"
            };
            return new JsonResult(response);
        }
    }
}
