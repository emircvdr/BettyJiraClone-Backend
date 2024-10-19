using JiraCloneBackend.Data;
using JiraCloneBackend.DTOs.WorkplaceInviteDTOs;
using JiraCloneBackend.Models;
using JiraCloneBackend.Services; // Modeli dahil etmeyi unutmayın
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class WorkplaceInviteController : ControllerBase
{
    private readonly IWorkplaceInviteService _workplaceInviteService;

    public WorkplaceInviteController(IWorkplaceInviteService workplaceInviteService)
    {
        _workplaceInviteService = workplaceInviteService;
    }

    [HttpPost("sendInvite")]
    public async Task<IActionResult> SendInvite([FromBody] SendInviteDTO dto)
    {
        var result = await _workplaceInviteService.SendWorkplaceInviteAsync(dto);
        
        return Ok(result);
    }

    [HttpPut("respondToInvite/{id}")]
    public async Task<IActionResult> RespondToInvite(int id, [FromBody] RespondeInviteDTO dto)
    {
        var result = await _workplaceInviteService.RespondToInviteAsync(id, dto);
        
        return Ok(result);
    }

    [HttpGet("getInviteById/{id}")]
    public async Task<IActionResult> GetInviteById(int id)
    {
        var result = await _workplaceInviteService.GetInviteByIdAsync(id);

        return Ok(result);
    }

    [HttpGet("getInvitesByUser/{id}")]
    public async Task<IActionResult> GetInvitesByUser(int id)
    {
        var result = await _workplaceInviteService.GetInvitesByUser(id);
        return Ok(result); 
    }
}