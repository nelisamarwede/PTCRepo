using PTC.Domain.EF.Context;
using PTC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.Domain.EF.Commands
{
    public class CalculationCommands : CommandBase
    {
        public CalculationCommands(ApplicationContext applicationContext) 
            : base(applicationContext)
        {

        }

        public TaxCalculation AddCalculation(TaxCalculation calculation)
        {

            return calculation;
        }
        public TaxCalculation UpdateCalculation(TaxCalculation calculation)
        {

            return calculation;
        }
        public bool DeleteCalculation(TaxCalculation calculation)
        {

            return true;
        }
    }
}
