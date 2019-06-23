using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.Domain.Entities
{
    public class TaxCalculation
    {
        public int? Id { get; set; }

        public string FullName { get; set; }

        public decimal Income { get; set; }

        public string PostalCode { get; set; }

        public decimal CalculatedTax { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
