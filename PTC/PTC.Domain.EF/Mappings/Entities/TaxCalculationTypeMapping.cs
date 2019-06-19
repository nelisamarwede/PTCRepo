using PTC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PTC.Domain.EF.Mappings.Entities
{
    public class TaxCalculationTypeMapping : EntityMapping<TaxCalculationType>
    {
        public override void Configure(EntityTypeBuilder<TaxCalculationType> builder)
        {
            builder.ToTable("TaxCalculationType");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Property(i => i.TypeName).IsRequired();
        }
    }
}
