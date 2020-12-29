using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentApp.Services;
using StudentApp.Services.Contracts;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using StudentApp.Tools.Configurations;

namespace StudentApp.IoC.Configuration.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services != null)
            {
                //We use single DataContext in entire project
                services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DataContext")));
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
