using Application.Common.Models;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("Policy1")]
    public class IdentityController : ControllerBase
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(AuthenticateRequest model, IIdentityService userService)
        {
            var answer = userService.Authenticate(model);
            if (answer == null)
                return Unauthorized();
            return Ok(answer);
        }
    }
}
