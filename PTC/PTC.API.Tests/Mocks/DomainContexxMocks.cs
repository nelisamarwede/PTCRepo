using FakeItEasy;
using PTC.Domain;
using PTC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.API.Tests.Mocks
{
    public class DomainContextMocks
    {
        public static DomainContext CreateMockDomainContext()
        {
            var fakeQueryProvider = A.Fake<IDomainQueryProvider>();
            var fakeRepoFactory = new FakedRepositoryFactory();
            var fakeContextFactory = A.Fake<IDomainContextFactory>();
            var fakeUserSessoin = A.Fake<IUserSession>();

            var mockContext = new DomainContext(fakeQueryProvider, fakeRepoFactory, fakeContextFactory);

            A.CallTo(() => fakeContextFactory.CreateScoped()).Returns(mockContext);

            return mockContext;
        }

        public class FakedRepositoryFactory : IRepositoryFactory
        {
            public IRepository<T> CreateRepository<T>() where T : class, new()
            {
                return A.Fake<IRepository<T>>();
            }
        }

    }
}
