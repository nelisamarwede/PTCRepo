using System.Linq;

namespace PTC.Domain.Queries.Providers
{
    public interface IQueryProvider<T> where T : class
    {
        IQueryable<T> Query { get; }
    }
}
