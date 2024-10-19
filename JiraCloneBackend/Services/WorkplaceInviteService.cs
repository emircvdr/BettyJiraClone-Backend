using JiraCloneBackend.Data;
using JiraCloneBackend.DTOs.WorkplaceInviteDTOs;
using JiraCloneBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JiraCloneBackend.Services;

public class WorkplaceInviteService : IWorkplaceInviteService
{
    private readonly AppDbContext _context;
    
    public WorkplaceInviteService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<WorkplaceInvıte> SendWorkplaceInviteAsync(SendInviteDTO dto)
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
        
        return invite;  
    }

    public async Task<WorkplaceInvıte> RespondToInviteAsync(int id, RespondeInviteDTO dto)
    {
        var invite = await _context.WorkplaceInvıtes.FindAsync(id);
        if (invite == null)
        {
            throw new Exception($"Invite with id {id} not found");
        }
        invite.Status = dto.Status; 
        invite.RespondedAt = DateTime.UtcNow;
        
        await _context.SaveChangesAsync();

        return invite;
    }

    public async Task<List<WorkplaceInvıte>> GetInviteByIdAsync(int id)
    {
        var invites = await _context.WorkplaceInvıtes
            .Where(i => i.InvitedId == id && i.Status == "Pending")
            .ToListAsync();

        return invites;
    }

    public async Task<List<WorkplaceInvıte>> GetInvitesByUser(int id)
    {
        var invites = await _context.WorkplaceInvıtes.Where(i => i.InvitedByUserId == id).ToListAsync();
        return invites; 
    }
}