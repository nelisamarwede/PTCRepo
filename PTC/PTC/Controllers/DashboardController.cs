using Microsoft.AspNetCore.Mvc;
using PTC.Domain.Entities;
using PTC.Domain.Queries.Providers;

namespace PTC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IQueryProvider<PostalCodeController> _postalCodeQueryProvider;
        private readonly IQueryProvider<ProgressiveRate> _progressiveRateQueryProvider;
        private readonly IQueryProvider<TaxType> _taxCalculationTypeQueryProvider;
        public DashboardController(IQueryProvider<PostalCodeController> postalCodeQueryProvider, IQueryProvider<ProgressiveRate> progressiveRateQueryProvider, IQueryProvider<TaxType> taxCalculationTypeQueryProvider)
        {
            _postalCodeQueryProvider = postalCodeQueryProvider;
            _progressiveRateQueryProvider = progressiveRateQueryProvider;
            _taxCalculationTypeQueryProvider = taxCalculationTypeQueryProvider;
        }

        public IActionResult Index()
        {

            return null;
        }

    }
}
