using JiraCloneBackend.Data;
using JiraCloneBackend.DTOs.WorkplacesDTOs;
using JiraCloneBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace JiraCloneBackend.Services;

public class WorkplaceService : IWorkplaces
{
    private readonly AppDbContext _context;
    
    public WorkplaceService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Workplace> CreateWorkplaces(CreateWorkplaceDTO dto)
    {
        var workplaces = new Workplace();
        workplaces.WorkplaceName = dto.WorkplaceName;
        workplaces.WorkplaceAdminId = dto.WorkplaceAdminId;

        await _context.Workplaces.AddAsync(workplaces);
        await _context.SaveChangesAsync();
        
        return workplaces;
    }

    public async Task<List<Workplace>> ListWorkplaces()
    {
        var workplaces = await _context.Workplaces.ToListAsync();

        return  workplaces;
    }

    public async Task<List<Workplace>> GetWorkplaces(int workplaceAdminId)
    {
        var workplace =   _context.Workplaces.Where(w => w.WorkplaceAdminId == workplaceAdminId).ToList();
        return workplace;
    }

    public async Task<Workplace> UpdateWorkplaces(UpdateWorkplaceDTO dto)
    {
        var workplace = await _context.Workplaces.FindAsync(dto.Id);
        if (workplace == null)
        {
            throw new KeyNotFoundException();
        }
        workplace.WorkplaceName = dto.WorkplaceName;
        await _context.SaveChangesAsync();
        return workplace;
    }
    
    public async Task<Workplace> DeleteWorkplaces(int id)
    {
        var workplace = await _context.Workplaces.FindAsync(id);

        if (workplace == null)
        {
            throw new KeyNotFoundException();
        }
        
        _context.Workplaces.Remove(workplace);  
        
        await _context.SaveChangesAsync();

        return workplace;
        

    }
}