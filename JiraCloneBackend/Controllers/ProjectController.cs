using JiraCloneBackend.DTOs.ProjectsDTOs;
using JiraCloneBackend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JiraCloneBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjects _projects;

    public ProjectController(IProjects projects)
    {
        _projects = projects;
    }
    
    [HttpPost]
    public async Task<IActionResult>CreateProjects([FromBody] CreateProjectDTO dto)
    {
        var result = await _projects.CreateProjects(dto);
        return Ok(result);
    }

    [HttpGet("GetProjectWithWorkplaceID/{workplaceId}")]

    public async Task<IActionResult> GetProjectWithWorkplaceID(int workplaceId)
    {
        var result = await _projects.GetProjectWithWorkplaceID(workplaceId);
        return Ok(result);
    }
}