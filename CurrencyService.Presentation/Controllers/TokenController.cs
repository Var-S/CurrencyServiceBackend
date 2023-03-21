using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CurrencyService.Presentation.Controllers;

public class TokenController : Controller
{
    [HttpGet("[action]")]
    public IActionResult GenerateToken()
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var token = new JwtSecurityToken(claims: claims, expires: DateTime.UtcNow.AddMinutes(20));

        return Ok(new { accessToken = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}