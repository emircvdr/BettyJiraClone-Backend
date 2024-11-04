namespace JiraCloneBackend.Models;

public class Projects
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int WorkplaceId { get; set; }
    public int AdminId { get; set; }
    
}