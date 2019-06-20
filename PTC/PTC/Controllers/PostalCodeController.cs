using Microsoft.AspNetCore.Mvc;
using PTC.Domain.Entities;
using PTC.Domain.Queries;
using PTC.Domain.Queries.Providers;
using System.Collections.Generic;
using System.Linq;

namespace PTC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostalCodeController : ControllerBase
    {
        private readonly IQueryProvider<PostalCode> _postalCodeQueryProvider;
        private readonly IQueryProvider<TaxType> _taxCalculationTypesQueryProvider;
        private readonly IQueryProvider<ProgressiveRate> _progressiveRatesQueryProvider;
        public PostalCodeController(IQueryProvider<PostalCode> postalCodeQueryProvider, IQueryProvider<TaxType> taxCalculationTypesQueryProvider
            ,IQueryProvider<ProgressiveRate> progressiveRatesQueryProvider)
        {
            _postalCodeQueryProvider = postalCodeQueryProvider;
            _taxCalculationTypesQueryProvider = taxCalculationTypesQueryProvider;
            _progressiveRatesQueryProvider = progressiveRatesQueryProvider;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PostalCode>> Get()
        {

            return PostalCodeQueries.GetPostalCodeTaxTypes(_postalCodeQueryProvider, _taxCalculationTypesQueryProvider).ToList();

        }
    }
}
