using PTC.Domain.EF.Inspectors.Calculators.Interface;
using PTC.Domain.Entities;
using PTC.Domain.Queries.Providers;
using PTC.Domain.Utilities;
using System.Linq;

namespace PTC.Domain.EF.Inspectors
{
    public class TaxInspector : ITaxInspector
    {
        public TaxCalculation TaxCalculationInspetor(TaxCalculation calculation, IQueryProvider<PostalCode> postalCodes
            , IProgressiveTaxCalculator progressiveTaxCalculator, IFlatRateTaxCalculator flatRateTaxCalculator, IFlatValueTaxCalculator flatValueTaxCalculator)
        {
            var postalCode = calculation.PostalCode;

            var taxTypeId = postalCodes.Query.Where(i => i.CodeName == postalCode).First().TaxTypeId;
            calculation = TaxTypeSelector(calculation, (int)taxTypeId, progressiveTaxCalculator, flatRateTaxCalculator, flatValueTaxCalculator);

            return calculation;
        }

        public TaxCalculation TaxTypeSelector(TaxCalculation calculation, int taxTypeId
            , IProgressiveTaxCalculator progressiveTaxCalculator, IFlatRateTaxCalculator flatRateTaxCalculator, IFlatValueTaxCalculator flatValueTaxCalculator)
        {

            if ((TaxTypeEnum)taxTypeId == TaxTypeEnum.ProgressiveTax)
            {
                calculation = progressiveTaxCalculator.ProcessTax(calculation);
            }
            else if ((TaxTypeEnum)taxTypeId == TaxTypeEnum.FlatRateTax)
            {
                calculation = flatRateTaxCalculator.ProcessTax(calculation);
            }
            else if ((TaxTypeEnum)taxTypeId == TaxTypeEnum.FlatValueTax)
            {
                calculation = flatValueTaxCalculator.ProcessTax(calculation);
            }

            return calculation;
        }
    }
}
