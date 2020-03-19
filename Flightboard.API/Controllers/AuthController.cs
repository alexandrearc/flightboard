using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Flightboard.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Flightboard.API.Controllers
{

    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public AuthController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(LoginRequest request)
        {
            var result = await _userManager.CreateAsync(new User { UserName = request.UserName }, request.Password);

            if (result.Succeeded)
            {
                return Accepted();
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("token")]
        public async Task<IActionResult> GenerateToken(LoginRequest loginInfo)
        {
            var user = await _userManager.FindByNameAsync(loginInfo.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginInfo.Password))
            {
                return Unauthorized();
            }

            var claims = new List<Claim>
            {
                new Claim("UserName", user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisNeedsToBeLongOtherwiseItCausesPIIHidden")); //TODO: Key should come from config or even key vault
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),

                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = creds
            };

            var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
