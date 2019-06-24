using PTC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.Domain.EF.Inspectors.Calculators.Interface
{
    public interface IFlatValueTaxCalculator
    {
        TaxCalculation ProcessTax(TaxCalculation calculation);
    }
}
