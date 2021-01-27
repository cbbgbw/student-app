using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentApp.API.Common.Settings;
using StudentApp.IoC.Configuration.DI;
using StudentApp.Tools.Configurations;
using System.IO;

namespace StudentApp.API.Tests.Controllers
{
    [TestClass]
    public class TestBase
    {
        internal IConfigurationRoot ConfigurationRoot;
        internal ServiceCollection Services;
        internal ServiceProvider ServiceProvider;

        public TestBase()
        {
            ConfigurationRoot = ConfigurationHelper.GetIConfigurationRoot(Directory.GetCurrentDirectory());
            var appSettings = ConfigurationRoot.GetSection(nameof(AppSettings));

            Services = new ServiceCollection();

            //We load EXACTLY the same settings (DI and others) than API real solution, what is much better for tests.
            Services.ConfigureBusinessServices((IConfiguration)ConfigurationRoot);

            Services.ConfigureMappings();
            Services.AddLogging();
            Services.Configure<AppSettings>(appSettings);

            ServiceProvider = Services.BuildServiceProvider();
        }

        ~TestBase()
        {
            if (ServiceProvider != null)
                ServiceProvider.Dispose();
        }
    }
}
