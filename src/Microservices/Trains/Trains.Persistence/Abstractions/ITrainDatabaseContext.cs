using Abstractions.Persistence;
using Microsoft.EntityFrameworkCore;
using Trains.Domain.Trains;

namespace Trains.Persistence.Abstractions;

public interface ITrainDatabaseContext : IDatabaseContext
{
    DbSet<Train> Trains { get; set; }
}
