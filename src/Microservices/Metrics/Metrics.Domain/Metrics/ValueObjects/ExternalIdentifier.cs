namespace Metrics.Domain.Metrics.ValueObjects;

public readonly record struct ExternalIdentifier
{
    /// <summary>
    /// Идентификатор сущности в других системах
    /// </summary>
    public string Identity { get; init; }
    
    public ExternalIdentifier(string identity)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(identity);
        Identity = identity.Trim();
    }
    
    public override string ToString() => Identity.ToString();
}
