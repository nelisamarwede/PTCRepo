using PTC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PTC.Domain.EF.Mappings.Entities
{
    public class FlatRateMapping : EntityMapping<FlatRate>
    {
        public override void Configure(EntityTypeBuilder<FlatRate> builder)
        {
            builder.ToTable("FlatRates");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Property(i => i.Rate).IsRequired();
            builder.Property(i => i.Amount).IsRequired();
            builder.Property(i => i.Description).IsRequired();

        }
    }
}
