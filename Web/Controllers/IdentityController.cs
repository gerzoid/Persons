﻿using Application.Common.Models;
using Domain.Entities;
using Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        [HttpPost("check")]
        [AllowAnonymous]
        public IActionResult Check(IIdentityService userService)
        {
            if (HttpContext.Items.TryGetValue("User", out var userObject) && userObject is User user)
                return Ok(new AuthenticateResponse(user,""));
            return Unauthorized();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(AuthenticateRequest model, IIdentityService userService)
        {
            var user = userService.Authenticate(model.Username, model.Password);
            if (user == null)
                return Unauthorized();

            var token = userService.GenerateJwtToken(user);

            return Ok(new AuthenticateResponse(user, token));
        }
    }
}
