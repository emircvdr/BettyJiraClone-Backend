namespace JiraCloneBackend.Models;

public class RelationWorkplace
{
    public int Id { get; set; }
    public int WorkplaceAdminId { get; set; }
    public int AcceptedUserId { get; set; }
    public int WorkplaceId { get; set; }
    
}