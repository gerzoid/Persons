namespace Application.Common.Models.Identity;

public class RefreshToken : JsonWebToken
{
    public RefreshToken(string token, long expiration) : base(token, expiration)
    {
    }
}
