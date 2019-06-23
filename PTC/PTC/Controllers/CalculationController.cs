using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PTC.Domain.EF.Commands;
using PTC.Domain.Entities;
using PTC.Domain.Queries.Providers;

namespace PTC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly CalculationCommands _calculationComms;
        private readonly IQueryProvider<TaxCalculation> _taxCalculationsQueryProvider;
        public CalculationController(IQueryProvider<TaxCalculation> taxCalculationsQueryProvider, CalculationCommands calculationComms)
     {
            _calculationComms = calculationComms;
            _taxCalculationsQueryProvider = taxCalculationsQueryProvider;
        }


        [HttpPost]
        public TaxCalculation Post([FromBody]TaxCalculation calculation)
        {
            calculation.CreatedDate = DateTime.UtcNow;

            _calculationComms.AddCalculation(calculation);

            return calculation;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TaxCalculation>> Get()
        {
            return _taxCalculationsQueryProvider.Query.ToList();

        }

        [HttpPut]
        public ActionResult<bool> Put([FromBody] TaxCalculation calculation)
        {
            _calculationComms.UpdateCalculation(calculation);
            return true;
        }

        //[HttpPost]
        //public ActionResult<bool> Post([FromBody]int calcId)
        //{
        //    var calculation = _taxCalculationsQueryProvider.Query.Where(i => i.Id == calcId).First();

        //    //_calculationComms.DeleteCalculation(calculation);

        //    return true;
        //}
    }
}