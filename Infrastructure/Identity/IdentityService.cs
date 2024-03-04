using Application.Common.Models;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web.Helpers;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly AppSettings _settings;
        private List<User> _users = new List<User>() { new User() { FirstName = "Gerz", LastName = "Gerz", Id = 1, Password = "korobok", Username = "gerz" } };

        public IdentityService(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(d => d.Username == model.Username && d.Password == model.Password);
            if (user == null)
                return null;

            var token = GenerateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        public User GetById(int id)
        {
            return _users.SingleOrDefault(d => d.Id == id);
        }

        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()), new Claim(ClaimTypes.NameIdentifier, user.Username) }, "Custom"),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
