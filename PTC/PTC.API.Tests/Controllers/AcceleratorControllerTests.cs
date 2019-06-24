using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTC.API.Controllers;
using PTC.Domain.EF.Inspectors;
using PTC.Domain.EF.Inspectors.Calculators.Interface;
using PTC.Domain.Entities;
using PTC.Domain.Queries.Providers;
using System.Collections.Generic;
using System.Linq;

namespace PTC.API.Tests.Controllers
{
    [TestClass]
    public class AcceleratorControllerTests
    {

        #region Locals

        private AcceleratorController _acceleratorController;
        private IQueryProvider<TaxCalculation> _taxCalculationQueryProvider;
        private IQueryProvider<PostalCode> _postalCodeQueryProvider;
        private IQueryProvider<TaxType> _taxCalculationTypesQueryProvider;
        private IQueryProvider<ProgressiveRate> _progressiveRatesQueryProvider;
        private ITaxInspector _inspector;
        private IProgressiveTaxCalculator _progressiveTaxCalculator;
        private IFlatRateTaxCalculator _flatRateTaxCalculator;
        private IFlatValueTaxCalculator _flatValueTaxCalculator;

        #endregion


        #region Mocking and Initializing

        [TestInitialize]
        public void Setup()
        {
            _taxCalculationQueryProvider = A.Fake<IQueryProvider<TaxCalculation>>();
            _postalCodeQueryProvider = A.Fake<IQueryProvider<PostalCode>>();
            _taxCalculationTypesQueryProvider = A.Fake<IQueryProvider<TaxType>>();
            _progressiveRatesQueryProvider = A.Fake<IQueryProvider<ProgressiveRate>>();

            _inspector = A.Fake<ITaxInspector>();
            _progressiveTaxCalculator = A.Fake<IProgressiveTaxCalculator>();
            _flatRateTaxCalculator = A.Fake<IFlatRateTaxCalculator>();
            _flatValueTaxCalculator = A.Fake<IFlatValueTaxCalculator>();
        }

        #endregion


        #region Mock Data

        public static class AcceleratorTestData
        {
            public static IQueryable<PostalCode> PostalCodes
            {
                get
                {
                    var list = new List<PostalCode>();

                    list.Add(new PostalCode { Id = 1, CodeName = "Area0001", TaxTypeId = 1 });
                    list.Add(new PostalCode { Id = 2, CodeName = "Area0002", TaxTypeId = 3 });
                    list.Add(new PostalCode { Id = 3, CodeName = "Area0003", TaxTypeId = 2 });
                    list.Add(new PostalCode { Id = 5, CodeName = "Area0005", TaxTypeId = 3 });
                    list.Add(new PostalCode { Id = 4, CodeName = "Area0004", TaxTypeId = 2 });
                    list.Add(new PostalCode { Id = 6, CodeName = "Area0006", TaxTypeId = 3 });
                    list.Add(new PostalCode { Id = 7, CodeName = "Area0007", TaxTypeId = 1 });

                    return list.AsQueryable();
                }
            }

            public static IQueryable<TaxType> TaxTypes
            {
                get
                {
                    var list = new List<TaxType>();

                    list.Add(new TaxType { Id = 1, TypeName = "Progressive Tax" });
                    list.Add(new TaxType { Id = 2, TypeName = "Flat Value Tax" });
                    list.Add(new TaxType { Id = 3, TypeName = "Flat Rate Tax" });

                    return list.AsQueryable();
                }
            }
        }

        #endregion



        #region Tests
        [TestMethod]
        public void Can_Get_TaxType_By_CodeName_And_Calculate_Tax()
        {

            A.CallTo(() => _postalCodeQueryProvider.Query).WithAnyArguments().Returns(AcceleratorTestData.PostalCodes);
            A.CallTo(() => _taxCalculationTypesQueryProvider.Query).WithAnyArguments().Returns(AcceleratorTestData.TaxTypes);

            var calculation = new TaxCalculation();
            calculation.Id = 1;
            calculation.FullName = "Joe Soup";
            calculation.Income = 784684;
            calculation.CreatedDate = System.DateTime.UtcNow;
            calculation.CalculatedTax = 0;
            calculation.PostalCode = "Area0007";

            _acceleratorController = new AcceleratorController(_taxCalculationQueryProvider, _postalCodeQueryProvider, _taxCalculationTypesQueryProvider
                , _progressiveRatesQueryProvider, _inspector, _progressiveTaxCalculator, _flatRateTaxCalculator, _flatValueTaxCalculator);

            var results = _acceleratorController.Get(calculation);

            Assert.IsNotNull(results.Value);


        }

        #endregion
    }
}
