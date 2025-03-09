
using System.Reflection;
using Application.Interfaces.Hangfire;
using Application.Interfaces.Repository;
using Application.Interfaces.Services;
using Application.Interfaces.UnitOfWork;
using Application.Profiles;
using Hangfire;
using Hangfire.SqlServer;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddMediatR(options =>
            {
                options.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

            services.AddHangfire(configuration =>
                 configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                 .UseSimpleAssemblyNameTypeSerializer()
                 .UseDefaultTypeSerializer()
                 .UseSqlServerStorage(Configuration.GetConnectionString("con"), new SqlServerStorageOptions
                 {
                     CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                     SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                     QueuePollInterval = TimeSpan.FromSeconds(15),
                     UseRecommendedIsolationLevel = true,
                   
                 }));
            
            services.AddHangfireServer();

            services.AddAutoMapper(Assembly.GetExecutingAssembly()); // This will scan the current assembly for mapping profiles

            // Register Mapster mappings
            MovieProfileMapster.RegisterMappings();

            // Add Mapster to DI
            services.AddMapster();
            return services;
        }
    }
}
