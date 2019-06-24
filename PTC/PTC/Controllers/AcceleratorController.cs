using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PTC.Domain.EF.Inspectors;
using PTC.Domain.EF.Inspectors.Calculators.Interface;
using PTC.Domain.Entities;
using PTC.Domain.Queries.Providers;

namespace PTC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcceleratorController : ControllerBase
    {
        private readonly IQueryProvider<TaxCalculation> _taxCalculationsQueryProvider;
        private readonly IQueryProvider<PostalCode> _postalCodeQueryProvider;
        private readonly IQueryProvider<TaxType> _taxCalculationTypesQueryProvider;
        private readonly IQueryProvider<ProgressiveRate> _progressiveRatesQueryProvider;
        private readonly ITaxInspector _inspector;
        private readonly IProgressiveTaxCalculator _progressiveTaxCalculator;
        private readonly IFlatRateTaxCalculator _flatRateTaxCalculator;
        private readonly IFlatValueTaxCalculator _flatValueTaxCalculator;

        public AcceleratorController(IQueryProvider<TaxCalculation> taxCalculationsQueryProvider, IQueryProvider<PostalCode> postalCodeQueryProvider
            , IQueryProvider<TaxType> taxCalculationTypesQueryProvider
            , IQueryProvider<ProgressiveRate> progressiveRatesQueryProvider
            , ITaxInspector inspector, IProgressiveTaxCalculator progressiveTaxCalculator, IFlatRateTaxCalculator flatRateTaxCalculator
            , IFlatValueTaxCalculator flatValueTaxCalculator)
        {
            _taxCalculationsQueryProvider = taxCalculationsQueryProvider;
            _postalCodeQueryProvider = postalCodeQueryProvider;
            _taxCalculationTypesQueryProvider = taxCalculationTypesQueryProvider;
            _progressiveRatesQueryProvider = progressiveRatesQueryProvider;
            _inspector = inspector;
            _progressiveTaxCalculator = progressiveTaxCalculator;
            _flatRateTaxCalculator = flatRateTaxCalculator;
            _flatValueTaxCalculator = flatValueTaxCalculator;
        }

        [HttpPatch]
        public ActionResult<TaxCalculation> Get([FromBody] TaxCalculation calculation)
        {
            calculation = _inspector.TaxCalculationInspetor(calculation, _postalCodeQueryProvider, _progressiveTaxCalculator, _flatRateTaxCalculator, _flatValueTaxCalculator);

            return calculation;
        }
    }
}