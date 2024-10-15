using System.Reflection;
using JiraCloneBackend.Migrations;
using JiraCloneBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace JiraCloneBackend.Data;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Workplace> Workplaces { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
   
}