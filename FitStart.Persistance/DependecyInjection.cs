using FitStart.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FitStart.Persistance
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<FitStartDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IFitStartDbContext>(provider => provider.GetService<FitStartDbContext>());
            return services;
        }
    }
}
