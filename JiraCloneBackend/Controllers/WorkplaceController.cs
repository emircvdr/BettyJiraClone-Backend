using JiraCloneBackend.Data;
using JiraCloneBackend.DTOs.WorkplacesDTOs;
using JiraCloneBackend.Models;
using JiraCloneBackend.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class WorkplaceController : ControllerBase
{
    private readonly IWorkplaces _workplacesService;

    public WorkplaceController(IWorkplaces workplacesService)
    {
        _workplacesService = workplacesService;
    }

    [HttpPost("createWorkplace")]

    public async Task<IActionResult> CreateWorkplace([FromBody] CreateWorkplaceDTO workplaceDTO)
    {
        var result = await _workplacesService.CreateWorkplaces(workplaceDTO);
        return Ok(result);
        
    }


    [HttpGet("listWorkplaces")]

    public async Task<IActionResult> GetWorkplaces()
    {
        var result = await _workplacesService.ListWorkplaces();
        return Ok(result);
    }

    [HttpGet("getWorkplaces/{workplaceAdminId}")]
    public async Task<IActionResult> GetWorkplaces(int workplaceAdminId)
    {
        var result = await _workplacesService.GetWorkplaces(workplaceAdminId);
        return Ok(result);
    }
    
    [HttpPut("updateWorkplace")]
    public async Task<IActionResult> UpdateWorkplace([FromBody] UpdateWorkplaceDTO workplaceDTO)
    {
        var result = await _workplacesService.UpdateWorkplaces(workplaceDTO);
        return Ok(result);
    }
    
    [HttpDelete("deleteWorkplaces/{id}")]
    public async Task<IActionResult> DeleteWorkplace(int id)
    {
        var result = await _workplacesService.DeleteWorkplaces(id);
        return Ok(result);
    }

}
