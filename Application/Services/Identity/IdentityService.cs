using Application.Configuration;
using Domain.Entities;
using Domain.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Identity;

public class IdentityService(IOptions<AppSettings> settings, IHttpContextAccessor httpContext) : IIdentityService
{
    private readonly AppSettings _settings = settings.Value;
    private readonly IHttpContextAccessor _httpContext = httpContext;

    private List<User> _users = new() { new User() { FirstName = "Gerz", LastName = "Gerz", Id = 1, Password = "korobok", Username = "gerz", IsAdmin = true } };

    public User? Authenticate(string login, string password)
    {
        return _users.SingleOrDefault(d => d.Username == login && d.Password == password);
    }

    public User GetById(int id)
    {
        return _users.SingleOrDefault(d => d.Id == id);
    }

    public User? GetCurrentUser()
    {
        if (_httpContext.HttpContext.Items.TryGetValue("User", out var userObject) && userObject is User user)
            return user;
        return null;
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
