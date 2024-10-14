using JiraCloneBackend.Data;
using JiraCloneBackend.DTOs.UserDTOs;
using JiraCloneBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace JiraCloneBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _context.Users.ToList();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
    {
        if (createUserDTO == null) return BadRequest();

        var user = new User();
        
        user.Username = createUserDTO.Username;
        user.Email = createUserDTO.Email;
        user.Password = createUserDTO.Password;
        user.FirstName = "";
        user.LastName = "";
        
        await _context.Users.AddAsync(user);
        
        await _context.SaveChangesAsync();
        
        return Ok(user);
        
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO updateUserDTO , int id)
    {
        if (updateUserDTO == null) return BadRequest();
        if (id == null || id == 0 || id < 0) return BadRequest();
        
        var user = await _context.Users.FindAsync(id);
        
        if (user == null) return NotFound();
        
        user.FirstName = updateUserDTO.FirstName;
        user.LastName = updateUserDTO.LastName;
        
        var result = await _context.SaveChangesAsync();
        
        return Ok(result);
    
        
    }
}
