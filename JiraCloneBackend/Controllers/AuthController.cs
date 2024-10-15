using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JiraCloneBackend.Data;
using JiraCloneBackend.DTOs.LoginDTOs;
using JiraCloneBackend.DTOs.UserDTOs;
using JiraCloneBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JiraCloneBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{

    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthController(AppDbContext context , IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
        
    }
    
    
    private string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
    private bool VerifyPassword(string inputPassword, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(inputPassword, passwordHash);
    }

    private string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginDTO loginDTO)
    {
        if (loginDTO == null || string.IsNullOrEmpty(loginDTO.Email) || string.IsNullOrEmpty(loginDTO.Password))
        {
            return BadRequest("Invalid login or password");
        }
        
        var user = _context.Users.FirstOrDefault(u => u.Email == loginDTO.Email);

        if (user == null)
        {
            return BadRequest("Invalid email or password");
        }

        if (!VerifyPassword(loginDTO.Password, user.Password))
        {
            return BadRequest("Invalid password");
        }
        
        var token = GenerateJwtToken(user);
        
        return Ok(new {Token = token , UserId = user.Id});
    }
    

    [HttpGet("GetList")]
    public IActionResult GetUsers()
    {
        var users = _context.Users.ToList();
        return Ok(users);
    }

    [HttpPost("register")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
    {
        if (createUserDTO == null) return BadRequest();
        
        var existingUser = _context.Users.FirstOrDefault(u => u.Email == createUserDTO.Email);
        if (existingUser != null)
        {
            return BadRequest("Email already exists");
        }

        var user = new User();
        
        user.Username = createUserDTO.Username;
        user.Email = createUserDTO.Email;
        user.Password = HashPassword(createUserDTO.Password);
        
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        
        var token = GenerateJwtToken(user);
        
        return Ok(new {Token = token, UserId = user.Id});
        
    }

    [HttpGet("GetUser/{id}")]
    public IActionResult GetUser(int id) => Ok(_context.Users.FirstOrDefault(u => u.Id == id));
    
    
    // [HttpPut]
    // public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO updateUserDTO , int id)
    // {
    //     if (updateUserDTO == null) return BadRequest();
    //     if (id == null || id == 0 || id < 0) return BadRequest();
    //     
    //     var user = await _context.Users.FindAsync(id);
    //     
    //     if (user == null) return NotFound();
    //     
    //     user.FirstName = updateUserDTO.FirstName;
    //     user.LastName = updateUserDTO.LastName;
    //     
    //     var result = await _context.SaveChangesAsync();
    //     
    //     return Ok(result);
    //
    //     
    // }
}
