using PTC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.Domain.EF.Commands.Interface
{
    public interface ICalculationCommands
    {
        TaxCalculation AddCalculation(TaxCalculation calculation);
        TaxCalculation UpdateCalculation(TaxCalculation calculation);
        bool DeleteCalculation(TaxCalculation calculation);
    }
}
