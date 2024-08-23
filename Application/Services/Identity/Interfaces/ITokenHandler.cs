using Application.Common.Models.Identity;
using Domain.Entities;

namespace Application.Services.Identity.Interfaces
{
    public interface ITokenHandler
    {
        AccessToken CreateAccessToken(User user);
        RefreshToken TakeRefreshToken(string token, string email);
        void RevokeRefreshToken(string token, string email);
    }

}
