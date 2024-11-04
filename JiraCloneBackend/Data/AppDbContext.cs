using System.Reflection;
using JiraCloneBackend.Migrations;
using JiraCloneBackend.Models;
using Microsoft.EntityFrameworkCore;
using Projects = JiraCloneBackend.Models.Projects;

namespace JiraCloneBackend.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Workplace> Workplaces { get; set; }
    public DbSet<WorkplaceInvıte> WorkplaceInvıtes { get; set; }
    
    public DbSet<RelationWorkplace> RelationWorkplaces { get; set; }
    
    public DbSet<Projects> Projects { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
   
}