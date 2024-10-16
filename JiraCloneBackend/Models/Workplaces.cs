namespace JiraCloneBackend.Models;

public class Workplace
{
    public int Id { get; set; }               // Unique identifier for the workplace
    public string WorkplaceName { get; set; } // Name of the workplace
    public int WorkplaceAdminId { get; set; } // Foreign key to the user who is the admin of this workplace
}
