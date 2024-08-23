using Application.Common.Models.Response;


namespace Application.Services.Identity.Interfaces

{
    public interface IIdentityService
    {
        Task<TokenResponse> CreateAccessTokenAsync(string email, string password);
        Task<TokenResponse> RefreshTokenAsync(string refreshToken, string userEmail);
        void RevokeRefreshToken(string refreshToken, string userEmail);
    }
}
