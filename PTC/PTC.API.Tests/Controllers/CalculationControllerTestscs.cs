

using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTC.API.Controllers;
using PTC.Domain.EF.Commands.Interface;
using PTC.Domain.Entities;
using PTC.Domain.Queries.Providers;
using System.Collections.Generic;
using System.Linq;

namespace PTC.API.Tests.Controllers
{
    [TestClass]
    public class CalculationControllerTestscs
    {

        #region Globals

        private CalculationController _calculationController;
        private IQueryProvider<TaxCalculation> _taxCalculationQueryProvider;
        private ICalculationCommands _calculationComm;
        #endregion


        #region Mocking and Initializing

        [TestInitialize]
        public void Setup()
        {
            var fakeQueryProvider = A.Fake<IQueryProvider>();


            _taxCalculationQueryProvider = A.Fake<IQueryProvider<TaxCalculation>>();
            _calculationComm = A.Fake<ICalculationCommands>();

        }

        #endregion


        #region Mock Data

        public static class CalculationTestData
        {
            public static IQueryable<TaxCalculation> TaxCalculations
            {
                get
                {
                    var list = new List<TaxCalculation>();

                    list.Add(new TaxCalculation
                    {
                        Id = 1,
                        FullName = "Joe Soup",
                        Income = 123456,
                        CreatedDate = System.DateTime.UtcNow,
                        CalculatedTax = 0
                    });
                    list.Add(new TaxCalculation
                    {
                        Id = 2,
                        FullName = "Joe Soup",
                        Income = 654321,
                        CreatedDate = System.DateTime.UtcNow,
                        CalculatedTax = 0
                    });
                    list.Add(new TaxCalculation
                    {
                        Id = 3,
                        FullName = "Joe Soup",
                        Income = 145632,
                        CreatedDate = System.DateTime.UtcNow,
                        CalculatedTax = 0
                    });
                    list.Add(new TaxCalculation
                    {
                        Id = 4,
                        FullName = "Joe Soup",
                        Income = 42536,
                        CreatedDate = System.DateTime.UtcNow,
                        CalculatedTax = 0
                    });

                    return list.AsQueryable();
                }
            }
        }

        #endregion



        #region Tests

        [TestMethod]
        public void Can_Get_Stored_TaxCalculations()
        {

            A.CallTo(() => _taxCalculationQueryProvider.Query).WithAnyArguments().Returns(CalculationTestData.TaxCalculations);

            _calculationController = new CalculationController(_taxCalculationQueryProvider, _calculationComm);

            var results = _calculationController.Get();


            Assert.IsTrue(results.Value.Count() > 0);//There is or are postal codes...

            foreach (var calculation in results.Value)
            {
                Assert.IsTrue(calculation.Income > 0);//there should always be a positive number as an income
                Assert.IsTrue(calculation.Id > 0); //the id should always be available on each record for a Delete or Updates?
                Assert.IsTrue(calculation.PostalCode != ""); //There should alwasy be a postal code, no empty string is expected by the Client
            }

        }


        //[TestMethod]
        //public void 

        #endregion


    }
}
