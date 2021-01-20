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
                services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DataContext"), b => b.MigrationsAssembly("StudentApp.API")));
                services.AddTransient<IUserService, UserService>();
                services.AddTransient<ISubjectService, SubjectService>();
                services.AddTransient<IProjectService, ProjectService>();
                services.AddTransient<ISemesterService, SemesterService>();
                services.AddTransient<IEventService, EventService>();
            }
        }

        public static void ConfigureMappings(this IServiceCollection services)
        {
            //Automap settings
            services?.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
