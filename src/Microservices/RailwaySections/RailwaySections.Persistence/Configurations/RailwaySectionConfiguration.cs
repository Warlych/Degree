using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RailwaySections.Domain.RailwaySections;
using RailwaySections.Domain.RailwaySections.ValueObjects.RailwaySections;

namespace RailwaySections.Persistence.Configurations;

public sealed class RailwaySectionConfiguration : IEntityTypeConfiguration<RailwaySection>
{
    public void Configure(EntityTypeBuilder<RailwaySection> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion<Guid>(x => x.Identity, x => new RailwaySectionId(x));
        builder.ComplexProperty(x => x.Title);
        builder.ComplexProperty(x => x.Parameters);
    }
}
