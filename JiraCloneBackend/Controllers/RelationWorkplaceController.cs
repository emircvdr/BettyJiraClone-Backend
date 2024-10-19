using JiraCloneBackend.DTOs.RelationWorkplaceDTOs;
using JiraCloneBackend.Models;
using JiraCloneBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace JiraCloneBackend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class RelationWorkplaceController : ControllerBase
{
    private readonly IRelationWorkplace _relationWorkplace;

    public RelationWorkplaceController(IRelationWorkplace relationWorkplace)
    {
        _relationWorkplace = relationWorkplace;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRelationWorkplace([FromBody] CreateRelationWorkplace dto)
    {
        var result = await _relationWorkplace.CreateRelationWorkplace(dto);
        return Ok(result);
    }

    [HttpGet("GetRelationListByUserId/{acceptedUserId}")]
    public async Task<IActionResult> GetRelationWorkplaceByUserId(int acceptedUserId)
    {
        var result = await _relationWorkplace.GetRelationListByUserId(acceptedUserId);
        return Ok(result);
    }
}