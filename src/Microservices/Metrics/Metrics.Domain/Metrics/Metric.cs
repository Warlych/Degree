using Abstractions.Domain.AggregateRoot;
using Metrics.Domain.Metrics.ValueObjects.Metrics;

namespace Metrics.Domain.Metrics;

/// <summary>
/// Объект метрики (по скорости, длине, весу, на ж/д участке)
/// </summary>
public sealed class Metric : AggregateRoot<MetricId>
{
    
    public Metric(MetricId id) : base(id)
    {
    }
}
