using PTC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PTC.Domain.EF.Mappings.Entities
{
    public class TaxTypeMapping : EntityMapping<TaxType>
    {
        public override void Configure(EntityTypeBuilder<TaxType> builder)
        {
            builder.ToTable("TaxTypes");
            
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Property(i => i.TypeName).IsRequired();
        }
    }
}
