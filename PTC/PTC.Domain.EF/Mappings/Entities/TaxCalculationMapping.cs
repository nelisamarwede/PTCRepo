using PTC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PTC.Domain.EF.Mappings.Entities
{
    public class TaxCalculationMapping : EntityMapping<TaxCalculation>
    {
        public override void Configure(EntityTypeBuilder<TaxCalculation> builder)
        {
            builder.ToTable("TaxCalculations");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Property(i => i.FullName).IsRequired();
            builder.Property(i => i.Income).IsRequired();
            builder.Property(i => i.PostalCode).IsRequired();
            builder.Property(i => i.CalculatedTax).IsRequired();
            builder.Property(i => i.CreatedDate).IsRequired();
        }
    }
}
