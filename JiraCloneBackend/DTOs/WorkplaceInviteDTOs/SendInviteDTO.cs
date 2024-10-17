namespace JiraCloneBackend.DTOs.WorkplaceInviteDTOs;

public class SendInviteDTO
{
    public int WorkplaceId { get; set; }
    
    public int InvitedId { get; set; }
    public string InvitedEmail { get; set; }
    public int InvitedByUserId { get; set; }
}