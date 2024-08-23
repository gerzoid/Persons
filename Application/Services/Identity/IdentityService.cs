using Application.Common.Models.Response;
using Application.Services.Identity.Interfaces;
using Application.Services.Identity.Tokens;
using Domain.Entities;
using Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Application.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        //private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenHandler _tokenHandler;
        private readonly UserService _userService;
        private readonly SigningConfigurations _signingConfigurations;


        public IdentityService(IPasswordHasher passwordHasher, ITokenHandler tokenHandler, SigningConfigurations signingConfigurations, UserService userService)
        {
            _passwordHasher = passwordHasher;
            _tokenHandler = tokenHandler;
            _signingConfigurations = signingConfigurations;
            _userService = userService;
        }

        public async Task<TokenResponse> CreateAccessTokenAsync(string login, string password)
        {
            /*var user = await _userService.FindByEmailAsync(email);
            if (user == null || !_passwordHasher.PasswordMatches(password, user.Password))
            {
                return new TokenResponse(false, "Invalid credentials.", null);
            }*/

            var user = _userService.Users().SingleOrDefault(d => d.Username == login && d.Password == password);
            if (user == null)
            {
                return new TokenResponse(false, "Invalid credentials.", null);
            }

            var token = _tokenHandler.CreateAccessToken(user);

            return new TokenResponse(true, null, token);
        }

        public async Task<TokenResponse> RefreshTokenAsync(string refreshToken, string login)
        {
            // get token matching given token and email address
            var token = _tokenHandler.TakeRefreshToken(refreshToken, login);

            if (token == null)
            {
                return new TokenResponse(false, "Invalid refresh token.", null);
            }

            if (token.IsExpired())
            {
                return new TokenResponse(false, "Expired refresh token.", null);
            }
            
            var user = _userService.Users().SingleOrDefault(d => d.Username == login);
            //var user = await _userService.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return new TokenResponse(false, "Invalid refresh token.", null);
            }

            var accessToken = _tokenHandler.CreateAccessToken(user);
            return new TokenResponse(true, null, accessToken);
        }

        public void RevokeRefreshToken(string refreshToken, string email)
        {
            _tokenHandler.RevokeRefreshToken(refreshToken, email);
        }


        /*public User? Authenticate(string login, string password)
        {
            return _users.SingleOrDefault(d => d.Username == login && d.Password == password);
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
                Claims = new List<Claim>
                    {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(ClaimTypes.Role, "Admin"),
                    }; 
                Expires = DateTime.UtcNow.AddMinutes(1),//AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }*/
    }
}
