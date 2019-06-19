using Microsoft.EntityFrameworkCore;
using PTC.Domain.EF.Context;
using PTC.Domain.Queries.Providers;
using System.Linq;

namespace PTC.Domain.EF.Queries
{
    public class QueryProvider<T> : IQueryProvider<T> where T : class
    {
        private readonly ApplicationContext _context;
        public QueryProvider(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }
        IQueryable<T> IQueryProvider<T>.Query => _context.Set<T>().AsNoTracking();
    }
}
