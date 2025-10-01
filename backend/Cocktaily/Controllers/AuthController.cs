using Cocktaily.Database;
using Cocktaily.Database.Entities;
using Cocktaily.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cocktaily.Controllers;

[ApiController]
[Route("/auth")]
public class AuthController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly AppDbContext _context;
    private readonly string _jwtKey;
    private readonly string _jwtIssuer;

    public AuthController(UserManager<AppUser> userManager, IConfiguration config, AppDbContext context)
    {
        _userManager = userManager;
        _context = context;
        _jwtKey = config["Jwt:Key"] ?? throw new ArgumentNullException("Jwt:Key not configured");
        _jwtIssuer = config["Jwt:Issuer"] ?? throw new ArgumentNullException("Jwt:Issuer not configured");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserModel userModel)
    {
        if (string.IsNullOrEmpty(userModel.UserName) || string.IsNullOrEmpty(userModel.Password))
        {
            return BadRequest("Username and password are required");
        }

        var user = await _userManager.FindByNameAsync(userModel.UserName);
        if (user == null || !await _userManager.CheckPasswordAsync(user, userModel.Password))
        {
            return Unauthorized();
        }
        
        // Generate access token
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim("username", user.UserName ?? "")
        };

        var accessToken = GenerateJwtToken(claims, TimeSpan.FromHours(24));

        return Ok(new { accessToken = accessToken });
    }

    private string GenerateJwtToken(Claim[] claims, TimeSpan expiresIn)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtIssuer,
            audience: null,
            claims: claims,
            expires: DateTime.Now.Add(expiresIn),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}