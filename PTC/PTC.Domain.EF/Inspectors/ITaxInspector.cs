using PTC.Domain.EF.Inspectors.Calculators.Interface;
using PTC.Domain.Entities;
using PTC.Domain.Queries.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.Domain.EF.Inspectors
{
    public interface ITaxInspector
    {
        TaxCalculation TaxCalculationInspetor(TaxCalculation calculation, IQueryProvider<PostalCode> postalCodes
            , IProgressiveTaxCalculator progressiveTaxCalculator, IFlatRateTaxCalculator flatRateTaxCalculator
            , IFlatValueTaxCalculator flatValueTaxCalculator);
        TaxCalculation TaxTypeSelector(TaxCalculation calculation, int taxTypeId, IProgressiveTaxCalculator progressiveTaxCalculator, IFlatRateTaxCalculator flatRateTaxCalculator
            , IFlatValueTaxCalculator flatValueTaxCalculator);
    }
}
