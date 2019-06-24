using PTC.Domain.EF.Inspectors.Calculators.Interface;
using PTC.Domain.Entities;

namespace PTC.Domain.EF.Inspectors.Calculators.Concrete
{
    public class FlatValueTaxCalculator : TaxBaseCalculator, IFlatValueTaxCalculator
    {
        public TaxCalculation ProcessTax(TaxCalculation calculation)
        {

            if (calculation.Income >= 200000)
            {
                calculation.CalculatedTax = 10000;
            }
            else
            {
                calculation.CalculatedTax = GetActualTax((decimal)GetPercentage(5), calculation.Income);
            }

            return calculation;
        }
    }
}
