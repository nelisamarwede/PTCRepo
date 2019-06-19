using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.Domain.Interfaces
{
    public interface IEntity
    {
        int? Id { get; set; }
    }

    public interface IEntityLookup
    {
        object LookupId { get; }

        object LookupValue { get; }
    }
}
