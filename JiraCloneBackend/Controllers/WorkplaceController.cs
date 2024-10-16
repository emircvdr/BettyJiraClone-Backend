using JiraCloneBackend.Data;
using JiraCloneBackend.DTOs.WorkplacesDTOs;
using JiraCloneBackend.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class WorkplaceController : ControllerBase
{
    private readonly AppDbContext _context;

    public WorkplaceController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("createWorkplace")]

    public async Task<IActionResult> CreateWorkplace([FromBody] CreateWorkplaceDTO workplaceDTO)
    {
        var workplaces = new Workplace();

        workplaces.WorkplaceName = workplaceDTO.WorkplaceName;
        workplaces.WorkplaceAdminId = workplaceDTO.WorkplaceAdminId;
        
        await _context.Workplaces.AddAsync(workplaces);
        await _context.SaveChangesAsync();
        
        return Ok(workplaces);
        
    }


    [HttpGet("getWorkplaces")]

    public async Task<IActionResult> GetWorkplaces()
    {
        var workplaces = _context.Workplaces.ToList();
        return Ok(workplaces);
    }

    [HttpGet("getWorkplaces/{workplaceAdminId}")]
    public async Task<IActionResult> GetWorkplaces(int workplaceAdminId)
    {
        var workplace = _context.Workplaces.Where(w => w.WorkplaceAdminId == workplaceAdminId).ToList();
        return Ok(workplace);
    }
    

   
}
