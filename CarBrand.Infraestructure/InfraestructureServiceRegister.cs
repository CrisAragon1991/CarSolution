using CarBrand.Domain.AgregateCardBrand;
using CarBrand.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarBrand.Infraestructure
{
    public static class InfraestructureServiceRegister
    {
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionString"];
            services.AddDbContext<Context.CarBrandContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<ICarBrandRepository, CarBrandRepository>();

            return services;
        }
    }
}
