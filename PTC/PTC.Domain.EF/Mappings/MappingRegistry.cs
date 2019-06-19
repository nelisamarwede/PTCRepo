using Microsoft.EntityFrameworkCore;
using PTC.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PTC.Domain.EF.Mappings
{
    internal static class MappingRegistry
    {
        private static List<IMappingConfig> _configs = new List<IMappingConfig>();

        static MappingRegistry()
        {
            var types = ReflectionUtils.GetTypes<IMappingConfig>();

            foreach (var type in types)
            {
                try
                {
                    if (Activator.CreateInstance(type) is IMappingConfig config)
                    {
                        _configs.Add(config);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        internal static void Configure(ModelBuilder modelBuilder)
        {
            foreach (var mapping in _configs)
            {
                mapping.Register(modelBuilder);
            }
        }
    }
}
