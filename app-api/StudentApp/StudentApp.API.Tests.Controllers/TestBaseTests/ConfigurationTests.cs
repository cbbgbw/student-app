using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentApp.API.Common.Settings;
using System.Threading.Tasks;

namespace StudentApp.API.Tests.Controllers.TestBaseTests
{
    [TestClass]
    public class ConfigurationTests : TestBase
    {
        [TestMethod]
        public async Task ConfigurationRoot_OK()
        {
            Assert.IsNotNull(ConfigurationRoot);
        }

        [TestMethod]
        public async Task AppSettingsIConfiguration_OK()
        {
            Assert.IsNotNull(ConfigurationRoot);

            var appSettings = ConfigurationRoot.GetSection(nameof(AppSettings));
            Assert.IsNotNull(appSettings);
        }

        [TestMethod]
        public async Task AppSettings_OK()
        {
            Assert.IsNotNull(ConfigurationRoot);

            var iConfiguration = ConfigurationRoot.GetSection(nameof(AppSettings));
            Assert.IsNotNull(iConfiguration);

            var appSettings = iConfiguration.Get<AppSettings>();
            Assert.IsNotNull(appSettings);
        }
    }
}
