using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.Domain.EF.Inspectors.Calculators.Concrete
{
    public abstract class TaxBaseCalculator
    {
        public static double GetPercentage(double value)
        {
            return value / 100;
        }

        public static decimal GetActualTax(decimal p, decimal income)
        {
            decimal tax = p * income;
            return (Math.Round(tax, 2));
        }
    }
}
