using PTC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.Domain.Entities
{
    public class ProgressiveRate: IEntity, IEntityLookup
    {
        public int? Id { get; set; }
        public string Rate { get; set; }
        public decimal EntryPoint { get; set; }
        public decimal EndPoint { get; set; }
        public string Description { get; set; }

        public object LookupId => Id;

        public object LookupValue => Description;
    }
}
