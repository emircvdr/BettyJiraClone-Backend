namespace JiraCloneBackend.Models;

public class WorkplaceInvıte
{
    public int Id { get; set; }
    public int WorkplaceId { get; set; }
    public int InvitedId { get; set; }
    public string InvitedEmail { get; set; }
    public int InvitedByUserId { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? RespondedAt { get; set; }
    
}