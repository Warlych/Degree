namespace Trains.Application.Handlers.Queries;

public sealed record TrainDto(Guid Id, string ExternalIdentifier, TrainParameters Parameters);

public sealed record TrainParameters(int NumberOfWagons, int GrossWeight, int NetWeight, int Lenght);
