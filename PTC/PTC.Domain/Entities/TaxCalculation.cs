using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.Domain.Entities
{
    public class TaxCalculation
    {
        public int? Id { get; set; }

        public double Income { get; set; }

        public string PostalCode { get; set; }

        public double CalculatedTax { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
