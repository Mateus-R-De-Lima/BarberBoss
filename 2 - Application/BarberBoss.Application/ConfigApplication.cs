using BarberBoss.Application.UseCases.Invoice.Register;
using Microsoft.Extensions.DependencyInjection;

namespace BarberBoss.Application
{
    public static class ConfigApplication
    {

        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
        }

        public static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterInvoiceUseCase, RegisterInvoiceUseCase>();          

        }

    }
}
