using Application.Common.Models;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(AuthenticateRequest model, IIdentityService identityService)
        {
            var answer = identityService.Authenticate(model);
            if (answer == null)
                return Unauthorized();
            return Ok(answer);
        }
    }
}
