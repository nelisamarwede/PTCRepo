using PTC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.Domain.EF.Inspectors.Calculators.Interface
{
    public interface IFlatRateTaxCalculator
    {
        TaxCalculation ProcessTax(TaxCalculation calculation);
    }
}
