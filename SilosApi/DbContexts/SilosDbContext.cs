using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SilosApi.Entities;

namespace SilosApi.DbContexts;

public class SilosDbContext(DbContextOptions<SilosDbContext> options) : DbContext(options)
{
    public DbSet<Silos> Silos { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}