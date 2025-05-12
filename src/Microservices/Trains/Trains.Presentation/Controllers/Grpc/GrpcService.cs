using Grpc.Core;
using Mediator;
using Trains.Application.Handlers.Queries.GetTrain;
using Trains.Contracts.Grpc.Impl.Trains;
using Trains.Domain.Trains.ValueObjects.Trains;
using TrainParameters = Trains.Contracts.Grpc.Impl.Trains.TrainParameters;

namespace Trains.Presentation.Controllers.Grpc;

public sealed class GrpcService : TrainsMicroservice.TrainsMicroserviceBase
{
    private readonly ISender _sender;

    public GrpcService(ISender sender)
    {
        _sender = sender;
    }
    
    public async override Task<GetTrainResponse> GetTrain(GetTrainRequest request, ServerCallContext context)
    {
        try
        {
            Guid.TryParse(request.Id, out var trainId);

            ArgumentNullException.ThrowIfNull(trainId, "train id");

            var train = await _sender.Send(new GetTrainQuery(new TrainId(trainId)), context.CancellationToken);

            return new GetTrainResponse
            {
                Succes = true,
                Train = new Train
                {
                    Id = train.Id.ToString(),
                    ExternalIdentifier = train.ExternalIdentifier,
                    Parameters = new TrainParameters
                    {
                        NumberOfWagons = train.Parameters.NumberOfWagons, 
                        GrossWeight = train.Parameters.GrossWeight, 
                        NetWeight = train.Parameters.NetWeight, 
                        Length = train.Parameters.Lenght
                    }
                }
            };
        }
        catch (Exception ex)
        {
            return new GetTrainResponse
            {
                Succes = false, Error = new Error { Message = ex.Message, AdditionalDetails = ex.StackTrace }
            };
        }
    }
}
