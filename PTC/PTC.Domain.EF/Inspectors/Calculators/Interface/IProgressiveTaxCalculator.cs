using PTC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.Domain.EF.Inspectors.Calculators.Interface
{
    public interface IProgressiveTaxCalculator
    {
        TaxCalculation ProcessTax(TaxCalculation calculation);
    }
}
