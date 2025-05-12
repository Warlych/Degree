using Abstractions.Persistence;

namespace RailwaySections.Persistence;

public sealed class UnitOfWork : IUnitOfWork
{
    public IDatabaseContext Context { get; }

    public Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return Context.Database.BeginTransactionAsync(cancellationToken);
    }
    
    public async Task CommitTransactionAsync(bool autoSaveEnable = true, CancellationToken cancellationToken = default)
    {
        if (autoSaveEnable)
        {
            Context.SaveChangesAsync(cancellationToken);
        }
        
        await Context.Database.CommitTransactionAsync(cancellationToken);
    }

    public Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        return Context.Database.RollbackTransactionAsync(cancellationToken);
    }
}
