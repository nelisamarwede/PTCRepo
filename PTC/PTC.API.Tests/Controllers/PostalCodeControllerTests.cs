using PTC.Domain;
using PTC.Domain.Entities;
using PTC.Domain.Queries.Providers;
using PTC.API.Controllers;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using PTC.Domain.EF.Queries;

namespace PTC.API.Tests.Controllers
{
    [TestClass]
    public class PostalCodeControllerTests
    {
        #region Mocking and Initializing

        private PostalCodeController _postalCodeController;
        private IQueryProvider<PostalCode> _postalCodeQueryProvider;
        private IQueryProvider<TaxType> _taxCalculationTypesQueryProvider;
        private IQueryProvider<ProgressiveRate> _progressiveRatesQueryProvider;


        [TestInitialize]
        public void Setup()
        {

            var fakeQueryProvider = A.Fake<IQueryProvider>();

            _postalCodeQueryProvider = A.Fake<IQueryProvider<PostalCode>>();
            _taxCalculationTypesQueryProvider = A.Fake<IQueryProvider<TaxType>>();
            _progressiveRatesQueryProvider = A.Fake<IQueryProvider<ProgressiveRate>>();
            _postalCodeController = new PostalCodeController(_postalCodeQueryProvider, _taxCalculationTypesQueryProvider, _progressiveRatesQueryProvider);

            var test = fakeQueryProvider.CreateQuery<PostalCode>(_postalCodeQueryProvider.Query.Expression);
        }
        #endregion


        #region MockData
        public static class PostalCodeTestData
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
        public void Can_Get_PostalCodes_With_Related_Tax_Types()
        {

            //A.CallTo(() => _postalCodeQueryProvider).WithAnyArguments().Returns(PostalCodeTestData.PostalCodes);
            //A.CallTo(() => _postalCodeQueryProvider).WithAnyArguments().Returns(PostalCodeTestData.TaxTypes);

        }

        #endregion
    }
}
