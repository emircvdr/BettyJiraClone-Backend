using JiraCloneBackend.Data;
using JiraCloneBackend.DTOs.ProjectsDTOs;
using JiraCloneBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace JiraCloneBackend.Services;

public class ProjectService : IProjects
{
    private readonly AppDbContext _context;

    public ProjectService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Projects> CreateProjects(CreateProjectDTO project)
    {
        var create = new Projects
        {
            Name = project.Name,
            WorkplaceId = project.WorkplaceId,
            AdminId = project.AdminId
        };
        await _context.Projects.AddAsync(create);
        await _context.SaveChangesAsync();
        
        return create;
    }

    public async Task<List<Projects>> GetProjectWithWorkplaceID(int workplaceId)
    {
        var result = await _context.Projects.Where(i => i.WorkplaceId == workplaceId).ToListAsync();
        return result;
    }
}