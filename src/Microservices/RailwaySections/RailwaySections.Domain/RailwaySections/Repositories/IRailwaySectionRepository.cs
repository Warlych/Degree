using Abstractions.Domain.AggregateRoot;
using RailwaySections.Domain.RailwaySections.ValueObjects.RailwaySections;

namespace RailwaySections.Domain.RailwaySections.Repositories;

public interface IRailwaySectionRepository : IAggregateRootRepository<RailwaySection, RailwaySectionId>;
