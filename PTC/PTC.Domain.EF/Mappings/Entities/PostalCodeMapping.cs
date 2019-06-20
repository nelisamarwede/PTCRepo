using PTC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PTC.Domain.EF.Mappings.Entities
{
    public class PostalCodeMapping : EntityMapping<PostalCode>
    {
        public override void Configure(EntityTypeBuilder<PostalCode> builder)
        {
            builder.ToTable("PostalCodes");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.CodeName).IsRequired();
            builder.Property(i => i.TaxTypeId).IsRequired();

        }
    }
}
