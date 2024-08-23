using Application.Common.Models;
using Application.Services;
using Application.Services.Identity.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        [HttpPost("check")]
        [AllowAnonymous]
        public IActionResult Check(UserService userService)
        {
            
            if (User.Identity.IsAuthenticated)
            {
                int id = Convert.ToInt32(((IEnumerable<Claim>)User.Claims).Where(x => x.Type == "id").First().Value);
                return Ok(new AuthenticateResponse(userService.Get(id), ""));
            }
            return Unauthorized();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AuthenticateRequest model, IIdentityService userService)
        {
            var user = userService.CreateAccessTokenAsync(model.Username, model.Password);
            if (user == null)
                return Unauthorized();

            var token = await userService.CreateAccessTokenAsync(model.Username, model.Password);

            return Ok(token);
            //return Ok(new AuthenticateResponse(user, token));
        }
    }
}
