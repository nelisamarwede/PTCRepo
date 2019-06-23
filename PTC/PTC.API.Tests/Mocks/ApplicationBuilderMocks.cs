using System;
using System.Collections.Generic;
using System.Text;

namespace PTC.API.Tests.Mocks
{
    public class ApplicationBuilderMocks
    {
        public static ApplicationBuilder CreateApplicationBuilderMocks()
        {
            var fakeApplicationBuilder = A.Fake<ApplicationBuilder>();

            return fakeApplicationBuilder;
        }
    }
}
