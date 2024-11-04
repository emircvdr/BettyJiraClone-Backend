using JiraCloneBackend.DTOs.ProjectsDTOs;
using JiraCloneBackend.Models;

namespace JiraCloneBackend.Services;

public interface IProjects
{
    public Task<Projects> CreateProjects(CreateProjectDTO project);
    
    public Task<List<Projects>> GetProjectWithWorkplaceID(int workplaceId);
}