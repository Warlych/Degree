using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace RailwaySections.Persistence.DesignTimeBuilders;

public class DesignTimeBuilder : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        Console.WriteLine("--- USE DESIGN TIME APPLICATION ---");

        var builder = new DbContextOptionsBuilder<DatabaseContext>()
                      .UseNpgsql()
                      .UseSnakeCaseNamingConvention()
                      .EnableDetailedErrors()
                      .EnableSensitiveDataLogging()
                      .LogTo(Console.WriteLine,
                             LogLevel.Information);
        
        return new DatabaseContext(builder.Options);
    }
}
