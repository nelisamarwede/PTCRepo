using PTC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PTC.Domain.EF.Mappings.Entities
{
    public class ProgressiveRateMapping : EntityMapping<ProgressiveRate>
    {
        public override void Configure(EntityTypeBuilder<ProgressiveRate> builder)
        {
            builder.ToTable("ProgressiveRate");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.Rate).IsRequired();
            builder.Property(i => i.EntryPoint).IsRequired();
            builder.Property(i => i.EndPoint).IsRequired();
            builder.Property(i => i.Description).IsRequired();
        }
    }
}
