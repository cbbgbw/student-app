using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentApp.Services;
using StudentApp.Services.Contracts;
using System.Reflection;
using StudentApp.Tools.Configurations;

namespace StudentApp.IoC.Configuration.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services != null)
            {
                services.AddDbContext<DataContext>();
                services.AddTransient<IUserService, UserService>();
                services.AddTransient<ISubjectService, SubjectService>();
            }
        }

        public static void ConfigureMappings(this IServiceCollection services)
        {
            if (services != null)
            {
                //Automap settings
                services.AddAutoMapper(Assembly.GetExecutingAssembly());
            }
        }
    }
}
