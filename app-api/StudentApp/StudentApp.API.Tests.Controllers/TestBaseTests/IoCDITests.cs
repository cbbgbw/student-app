using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentApp.API.Common.Settings;
using System.Threading.Tasks;

namespace StudentApp.API.Tests.Controllers.TestBaseTests
{
    [TestClass]
    public class IoCdiTests : TestBase
    {
        [TestMethod]
        public async Task IoC_DI_ServiceProvider_OK()
        {
            Assert.IsNotNull(ServiceProvider);
        }


        [TestMethod]
        public async Task IoC_DI_Mapper_OK()
        {
            Assert.IsNotNull(ServiceProvider);

            var mapper = ServiceProvider.GetRequiredService<IMapper>();
            Assert.IsNotNull(mapper);
        }

        [TestMethod]
        public async Task IoC_DI_LoggerFactory_OK()
        {
            var serviceProvider = Services.BuildServiceProvider();
            Assert.IsNotNull(serviceProvider);

            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            Assert.IsNotNull(loggerFactory);
        }

        [TestMethod]
        public async Task IoC_DI_IOptions_AppSettings_OK()
        {
            var serviceProvider = Services.BuildServiceProvider();
            Assert.IsNotNull(serviceProvider);

            var ioptions = serviceProvider.GetService<IOptions<AppSettings>>();
            Assert.IsNotNull(ioptions);
        }
    }
}
