using PTC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.Domain.Entities
{
    public class TaxType : IEntity, IEntityLookup
    {
        public int? Id { get; set; }
        public string TypeName { get; set; }

        public object LookupId => Id;
        public object LookupValue => TypeName;
    }
}
