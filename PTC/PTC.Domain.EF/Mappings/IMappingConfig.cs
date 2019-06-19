using Microsoft.EntityFrameworkCore;

namespace PTC.Domain.EF.Mappings
{
    public interface IMappingConfig
    {
        void Register(ModelBuilder modelBuilder);
    }
}
