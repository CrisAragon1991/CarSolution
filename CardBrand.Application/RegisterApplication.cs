using CardBrand.Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace CardBrand.Application
{
    public static class RegisterApplication
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCarBrandCommand).Assembly));
            return services;
        }
    }
}
