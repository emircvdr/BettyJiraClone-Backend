namespace JiraCloneBackend.DTOs.ProjectsDTOs;

public class CreateProjectDTO
{
    public string Name { get; set; }
    public int WorkplaceId { get; set; }
    public int AdminId  { get; set; }
}