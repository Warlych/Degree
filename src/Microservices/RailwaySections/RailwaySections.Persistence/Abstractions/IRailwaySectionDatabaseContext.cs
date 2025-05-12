using Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;
using RailwaySections.Domain.RailwaySections;

namespace RailwaySections.Persistence.Abstractions;

public interface IRailwaySectionDatabaseContext : IDatabaseContext
{
    DbSet<RailwaySection> RailwaySections { get; set; }
}
