using BarberBoss.Application.AutoMapper;
using BarberBoss.Application.UseCases.Invoices.Register;
using Microsoft.Extensions.DependencyInjection;

namespace BarberBoss.Application
{
    public static class ConfigApplication
    {

        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
            AddAutoMapper(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterInvoiceUseCase, RegisterInvoiceUseCase>();

        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<AutoMapping>();
            });

        }

    }
}
