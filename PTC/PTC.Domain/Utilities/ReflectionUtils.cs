using System;
using System.Collections.Generic;
using System.Linq;

namespace PTC.Domain.Utilities
{
    public static class ReflectionUtils
    {
        public static IEnumerable<Type> GetTypes<T>()
        {
            var typeToFind = typeof(T);

            var assembliesToScan = AppDomain.CurrentDomain.GetAssemblies();

            return assembliesToScan.Where(i => i.FullName.StartsWith("PTC"))
                .SelectMany(s => s.GetTypes())
                .Where(p => typeToFind.IsAssignableFrom(p) && !p.IsAbstract);
        }
    }
}
