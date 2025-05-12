using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RailwaySections.Domain.RailwaySections;
using RailwaySections.Domain.RailwaySections.Repositories;
using RailwaySections.Persistence.Abstractions;

namespace RailwaySections.Persistence.Repositories;

public sealed class RailwaySectionRepository : IRailwaySectionRepository
{
    private IRailwaySectionDatabaseContext _context;

    public RailwaySectionRepository(IRailwaySectionDatabaseContext context)
    {
        _context = context;
    }

    public Task<RailwaySection?> GetAsync(Expression<Func<RailwaySection, bool>> predicate,
                                          CancellationToken cancellationToken = default)
    {
        return _context.RailwaySections.Where(predicate ?? (_ => true)).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task AddAsync(RailwaySection aggregate, CancellationToken cancellationToken = default)
    {
        await _context.RailwaySections.AddAsync(aggregate, cancellationToken);
    }

    public Task DeleteAsync(RailwaySection aggregate, CancellationToken cancellationToken = default)
    {
        _context.RailwaySections.Remove(aggregate);
        
        return Task.CompletedTask;
    }
}
