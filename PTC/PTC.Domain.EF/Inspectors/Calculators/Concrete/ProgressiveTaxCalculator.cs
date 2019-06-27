using PTC.Domain.EF.Inspectors.Calculators.Interface;
using PTC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.Domain.EF.Inspectors.Calculators.Concrete
{
    public class ProgressiveTaxCalculator : TaxBaseCalculator, IProgressiveTaxCalculator
    {
        public TaxCalculation ProcessTax(TaxCalculation calculation)
        {
            decimal income = calculation.Income;

            decimal monthlyIncome = income / 12;

            if (monthlyIncome <= 8350)//10%
            {
                decimal perc = (decimal)GetPercentage(10);
                calculation.CalculatedTax = GetActualTax(perc, income);
            }

            else if (monthlyIncome >= 8351 && monthlyIncome <= 33950) //15%
            { 
                decimal perc = (decimal)GetPercentage(15);
                calculation.CalculatedTax = GetActualTax(perc, income);
            }

            else if (monthlyIncome >= 33951 && monthlyIncome <= 82250)
            { // 25%
                decimal perc = (decimal)GetPercentage(25);
                calculation.CalculatedTax = GetActualTax(perc, income);
            }
            else if (monthlyIncome >= 82251 && monthlyIncome <= 171550)
            { //28%
                decimal perc = (decimal)GetPercentage(28);
                calculation.CalculatedTax = GetActualTax(perc, income);
            }
            else if (monthlyIncome >= 171551 && monthlyIncome <= 372950)
            {//33%
                decimal perc = (decimal)GetPercentage(33);
                calculation.CalculatedTax = GetActualTax(perc, income);
            }
            else if (monthlyIncome >= 372951)
            {//35%
                decimal perc = (decimal)GetPercentage(35);
                calculation.CalculatedTax = GetActualTax(perc, income);
            }
            return calculation;
        }                
    }
}
