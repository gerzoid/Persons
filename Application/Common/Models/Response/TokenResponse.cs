using Application.Common.Models.Identity;

namespace Application.Common.Models.Response;


public class TokenResponse : BaseResponse
{
	public AccessToken Token { get; set; }

	public TokenResponse(bool success, string message, AccessToken token) : base(success, message)
	{
		Token = token;
	}
}
