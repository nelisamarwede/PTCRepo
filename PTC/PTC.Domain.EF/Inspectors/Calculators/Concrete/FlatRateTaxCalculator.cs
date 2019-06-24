using PTC.Domain.EF.Inspectors.Calculators.Interface;
using PTC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.Domain.EF.Inspectors.Calculators.Concrete
{
    public class FlatRateTaxCalculator : TaxBaseCalculator, IFlatRateTaxCalculator
    {
        public TaxCalculation ProcessTax(TaxCalculation calculation)
        {
            calculation.CalculatedTax = GetActualTax((decimal)GetPercentage(17.5), calculation.Income);
            return calculation;
        }
    }
}
