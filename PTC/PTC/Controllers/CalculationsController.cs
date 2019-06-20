using Microsoft.AspNetCore.Mvc;
using PTC.Domain.EF.Commands.Interface;
using PTC.Domain.Entities;
using PTC.Domain.Queries.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly ICalculationCommands _calculationComms;
        private readonly IQueryProvider<TaxCalculation> _taxCalculationsQueryProvider;
        public CalculationsController(ICalculationCommands calculationComms, IQueryProvider<TaxCalculation> taxCalculationsQueryProvider)
        {
            _calculationComms = calculationComms;
            _taxCalculationsQueryProvider = taxCalculationsQueryProvider;
        }

        public TaxCalculation AddCalculations(TaxCalculation calculation)
        {

            _calculationComms.AddCalculation(calculation);

            return calculation;
        }

        public TaxCalculation UpdateCalculations(TaxCalculation calculation)
        {

            _calculationComms.UpdateCalculation(calculation);

            return calculation;
        }

        public bool DeleteCalculation(TaxCalculation calculation)
        {

            _calculationComms.DeleteCalculation(calculation);

            return true;
        }

        public ActionResult<IEnumerable<TaxCalculation>> Get()
        {            
            _taxCalculationsQueryProvider.Query.ToList();

            return null;
        }
    }
}
