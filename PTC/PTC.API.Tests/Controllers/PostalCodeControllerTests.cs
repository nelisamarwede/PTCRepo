using PTC.Domain;
using PTC.Domain.Entities;
using PTC.Domain.Queries.Providers;
using PTC.API.Controllers;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace PTC.API.Tests.Controllers
{
    [TestClass]
    public class PostalCodeControllerTests
    {

        #region Globals

            private PostalCodeController _postalCodeController;     
        
        #endregion



        #region Mocking and Initializing


        [TestInitialize]
        public void Setup()
        {

            var fakeQueryProvider = A.Fake<IQueryProvider>();

            var postalCodeQueryProvider = A.Fake<IQueryProvider<PostalCode>>();
            var taxCalculationTypesQueryProvider = A.Fake<IQueryProvider<TaxType>>();


            A.CallTo(() => postalCodeQueryProvider.Query).WithAnyArguments().Returns(PostalCodeTestData.PostalCodes);
            A.CallTo(() => taxCalculationTypesQueryProvider.Query).WithAnyArguments().Returns(PostalCodeTestData.TaxTypes);
            _postalCodeController = new PostalCodeController(postalCodeQueryProvider, taxCalculationTypesQueryProvider);

            var test = fakeQueryProvider.CreateQuery<PostalCode>(postalCodeQueryProvider.Query.Expression);
        }
        #endregion


        #region Mock Data
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

            var results = _postalCodeController.Get();

            Assert.IsTrue(results.Value.Count() > 0);//There is or are postal codes...

            foreach (var item in results.Value)
            {
                Assert.IsNotNull(item.TaxType);//All existing Postal Codes are linked to their relevent types...
                Assert.AreEqual(item.TaxTypeId, item.TaxType.Id);//There hasn't been data errors like mis-matching ID's on the Query...
            }
            

        }

        #endregion
    }
}
