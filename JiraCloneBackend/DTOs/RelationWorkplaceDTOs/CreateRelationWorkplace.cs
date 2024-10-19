namespace JiraCloneBackend.DTOs.RelationWorkplaceDTOs;

public class CreateRelationWorkplace
{
    public int WorkplaceAdminId { get; set; }
    public int AcceptedUserId { get; set; }
    public int WorkplaceId { get; set; }
}