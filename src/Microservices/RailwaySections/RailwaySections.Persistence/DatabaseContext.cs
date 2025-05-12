using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RailwaySections.Domain.RailwaySections;
using RailwaySections.Persistence.Abstractions;

namespace RailwaySections.Persistence;

public sealed class DatabaseContext : DbContext, IRailwaySectionDatabaseContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    public DbSet<RailwaySection> RailwaySections { get; set; }
}
