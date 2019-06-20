using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.Domain.Entities
{
    public class FlatRate
    {
        public int? Id { get; set; }
        public string Rate { get; set; }

        public double Amount { get; set; }

        public string Description { get; set; }
    }
}
