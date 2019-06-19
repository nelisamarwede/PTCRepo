using PTC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.Domain.Entities
{
    public class PostalCode : IEntity, IEntityLookup
    {
        public int? Id { get; set; }
        public string CodeName { get; set; }
        public int TaxTypeId { get; set; }


        public object LookupId => Id;
        public object LookupValue => CodeName;
    }
}
