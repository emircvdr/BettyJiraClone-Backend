using JiraCloneBackend.DTOs.RelationWorkplaceDTOs;
using JiraCloneBackend.Models;

namespace JiraCloneBackend.Services;

public interface IRelationWorkplace
{
    public Task<RelationWorkplace> CreateRelationWorkplace(CreateRelationWorkplace dto);
    public Task<List<RelationWorkplace>> GetRelationListByUserId(int acceptedUserId);
}