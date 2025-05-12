using Abstractions.Domain.AggregateRoot;
using Trains.Domain.Trains.ValueObjects.Trains;

namespace Trains.Domain.Trains.Repositories;

public interface ITrainRepository : IAggregateRootRepository<Train, TrainId>;
