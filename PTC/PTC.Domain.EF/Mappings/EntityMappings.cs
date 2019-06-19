using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StaticDotNet.EntityFrameworkCore.ModelConfiguration;

namespace PTC.Domain.EF.Mappings
{
    public abstract class EntityMapping<T> : EntityTypeConfiguration<T>, IMappingConfig where T : class
    {
        public abstract override void Configure(EntityTypeBuilder<T> builder);

        public void Register(ModelBuilder modelBuilder)
        {
            Configure(modelBuilder.Entity<T>());
        }
    }
}
