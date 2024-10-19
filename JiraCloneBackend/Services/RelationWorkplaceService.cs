using JiraCloneBackend.Data;
using JiraCloneBackend.DTOs.RelationWorkplaceDTOs;
using JiraCloneBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace JiraCloneBackend.Services;

public class RelationWorkplaceService : IRelationWorkplace
{
    private readonly AppDbContext _context;

    public RelationWorkplaceService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<RelationWorkplace> CreateRelationWorkplace(CreateRelationWorkplace dto)
    {
        var create = new RelationWorkplace
        {
            WorkplaceId = dto.WorkplaceId,
            WorkplaceAdminId = dto.WorkplaceAdminId,
            AcceptedUserId = dto.AcceptedUserId,
        };
        await _context.RelationWorkplaces.AddAsync(create);
        await _context.SaveChangesAsync();
        
        return create;
    }

    public async Task<List<RelationWorkplace>> GetRelationListByUserId(int acceptedUserId)
    {
        var result = await _context.RelationWorkplaces
            .Where(i => i.AcceptedUserId == acceptedUserId)
            .ToListAsync();

        return result;
    }
}