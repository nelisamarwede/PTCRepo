
using PTC.Domain.EF.Commands;
using PTC.Domain.EF.Commands.Interface;
using PTC.Domain.Entities;
using PTC.Domain.Queries.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace PTC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly ICalculationCommands _calculationComms;
        private readonly IQueryProvider<TaxCalculation> _taxCalculationsQueryProvider;
        public CalculationsController(IQueryProvider<TaxCalculation> taxCalculationsQueryProvider, ICalculationCommands calculationComms)
        {
            _calculationComms = calculationComms;
            _taxCalculationsQueryProvider = taxCalculationsQueryProvider;
        }

        //public TaxCalculation AddCalculations(TaxCalculation calculation)
        //{


        //    _calculationComms.AddCalculation(calculation);
        //    return calculation;
        //}

        [HttpPost]
        public TaxCalculation Post([FromBody]TaxCalculation calculation)
        {
            calculation.CreatedDate = DateTime.UtcNow;

            _calculationComms.AddCalculation(calculation);

            return calculation;
        }
        //public TaxCalculation UpdateCalculations(TaxCalculation calculation)
        //{

        //    _calculationComms.UpdateCalculation(calculation);

        //    return calculation;
        //}

        //public bool DeleteCalculation(TaxCalculation calculation)
        //{

        //    _calculationComms.DeleteCalculation(calculation);

        //    return true;
        //}
        [HttpGet]
        public ActionResult<IEnumerable<TaxCalculation>> Get()
        {            
            return _taxCalculationsQueryProvider.Query.ToList();

        }
    }
}
