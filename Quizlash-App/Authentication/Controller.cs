using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Quizlash_App.Authentication.Register.Messager;
using Quizlash_App.Databases.PostgreSql.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Wolverine;

namespace Quizlash_App.Authentication;

[Route("api/authentication")]
[ApiController]
public class Controller : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly Databases.PostgreSql.Identity.IdentityContext _context;
    private readonly IMessageBus _messageBus;
    public Controller(UserManager<IdentityUser> userManager, 
        SignInManager<IdentityUser> signInManager,
        IConfiguration configuration,
        IdentityContext context,
        IMessageBus messageBus)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _context = context;
        _messageBus = messageBus;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var users = await _context.Users.ToListAsync();
        if (users == null || users.Count == 0)
        {
            return NotFound("No users found.");
        }
        return Ok(users);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Login.Payload payload)
    {
        var user = await _userManager.FindByEmailAsync(payload.Email);
        if (user == null)
        {
            return Unauthorized("Email has not been registered");
        }

        var result = await _userManager.CheckPasswordAsync(user, payload.Password);
        if (!result)
        {
            return Unauthorized("Invalid password.");
        }

        var token = GenerateToken(payload.Email);
        var response = new
        {
            Token = token,
        };
        return CreatedAtAction(nameof(Get), response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] Register.Payload payload)
    {
        var existingUser = await _userManager.FindByEmailAsync(payload.Email);
        if (existingUser != null)
        {
            return Conflict("Email is already in use.");
        }
        var newUser = new IdentityUser
        {
            UserName = payload.Email,
            Email = payload.Email,
            PhoneNumber = payload.PhoneNumber,
            EmailConfirmed=true
        };
        var result = await _userManager.CreateAsync(newUser, payload.Password);
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }
        await _messageBus.PublishAsync(new Message(Guid.Parse(newUser.Id),payload));
        return CreatedAtAction(nameof(Get), newUser.Id);
    }

    #region Token Generation
    private string GenerateToken(string email)
    {
        var keyString = _configuration["JWT:Key"];
        if (string.IsNullOrEmpty(keyString)) throw new InvalidOperationException("JWT key is not configured.");

        var key = Encoding.UTF8.GetBytes(keyString);
        var issuer = _configuration["JWT:Issuer"];
        var audience = _configuration["JWT:Audience"];

        var user = _context.Users.FirstOrDefault(u => u.Email == email);
        if (user == null)
            throw new InvalidOperationException("User not found");

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityKey = new SymmetricSecurityKey(key);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    #endregion

}
