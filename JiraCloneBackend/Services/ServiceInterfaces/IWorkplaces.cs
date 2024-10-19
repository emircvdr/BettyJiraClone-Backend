using JiraCloneBackend.DTOs.WorkplacesDTOs;
using JiraCloneBackend.Models;

namespace JiraCloneBackend.Services;

public interface IWorkplaces
{
    public Task<Workplace> CreateWorkplaces(CreateWorkplaceDTO dto);
    
    public Task<List<Workplace>> ListWorkplaces();
    
    public Task<List<Workplace>> GetWorkplaces(int workplaceAdminId);
    
    public Task<Workplace> UpdateWorkplaces(UpdateWorkplaceDTO dto);
    
    
    public Task<Workplace> DeleteWorkplaces(int id);
}