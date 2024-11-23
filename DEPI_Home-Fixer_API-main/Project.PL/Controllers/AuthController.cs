using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project.BLL.DTOs.Auth;
using Project.BLL.ServiceContracts;
using System.Security.Claims;
using System;

namespace Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn(LogInDto dto)
        {
            var user = await _authService.LogIn(dto);

            if (user != null)
            {
                // Create claims
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Sign in the user
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return Ok(user);

            }
            else
                return BadRequest(dto);
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(RegisterUserDto dto)
        {
            List<string> errors = new List<string>();

            if (ModelState.IsValid)
            {
                errors = await _authService.RegisterUser(dto);
            }

            if (errors.IsNullOrEmpty())
                return Ok(errors);

            return Ok(errors);
        }

        [HttpPost("RegisterTechnician")]
        public async Task<IActionResult> RegisterTechnician(RegisterTechnicianDto dto)
        {
            List<string> errors = new List<string>();

            if (ModelState.IsValid)
            {
                errors = await _authService.RegisterTechnician(dto);
            }
                return Ok(errors);
        }

        [HttpGet("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            await _authService.SignOut();
            return Ok();
        }

    }
}
