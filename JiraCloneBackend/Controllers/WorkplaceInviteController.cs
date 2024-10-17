using JiraCloneBackend.Data;
using JiraCloneBackend.DTOs.WorkplaceInviteDTOs;
using JiraCloneBackend.Models; // Modeli dahil etmeyi unutmayın
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class WorkplaceInviteController : ControllerBase
{
    private readonly AppDbContext _context;

    public WorkplaceInviteController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("sendInvite")]
    public async Task<IActionResult> SendInvite([FromBody] SendInviteDTO dto)
    {
        var invite = new WorkplaceInvıte
        {
            WorkplaceId = dto.WorkplaceId,
            InvitedId = dto.InvitedId,
            InvitedEmail = dto.InvitedEmail,
            InvitedByUserId = dto.InvitedByUserId,
            Status = "Pending",
            CreatedAt = DateTime.UtcNow
        };
        
        await _context.WorkplaceInvıtes.AddAsync(invite);
        await _context.SaveChangesAsync();
        
        return Ok(invite);
    }

    [HttpPut("respondToInvite/{id}")]
    public async Task<IActionResult> RespondToInvite(int id, [FromBody] RespondeInviteDTO dto)
    {
        var invite = await _context.WorkplaceInvıtes.FindAsync(id);
        if (invite == null)
        {
            return NotFound();
        }
        invite.Status = dto.Status; 
        invite.RespondedAt = DateTime.UtcNow;
        
        await _context.SaveChangesAsync();
        
        return Ok(invite);
    }

    [HttpGet("getInviteById/{id}")]
    public async Task<IActionResult> GetInviteById(int id)
    {
        var invites = await _context.WorkplaceInvıtes
            .Where(i => i.InvitedId == id && i.Status == "Pending")
            .ToListAsync();

        return Ok(invites);
    }

    [HttpGet("getInvitesByUser/{id}")]
    public async Task<IActionResult> GetInvitesByUser(int id)
    {
        var invites = await _context.WorkplaceInvıtes.Where(i => i.InvitedByUserId == id).ToListAsync();
        return Ok(invites); 
    }
}