using JiraCloneBackend.DTOs.WorkplaceInviteDTOs;
using JiraCloneBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace JiraCloneBackend.Services;

public interface IWorkplaceInviteService
{
    public Task<WorkplaceInvıte> SendWorkplaceInviteAsync(SendInviteDTO dto);
    public Task<WorkplaceInvıte> RespondToInviteAsync(int id, RespondeInviteDTO dto);
    public Task<List<WorkplaceInvıte>> GetInviteByIdAsync(int id);
    public Task<List<WorkplaceInvıte>> GetInvitesByUser(int id);
}