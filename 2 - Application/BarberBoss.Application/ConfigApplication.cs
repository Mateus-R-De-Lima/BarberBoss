using BarberBoss.Application.AutoMapper;
using BarberBoss.Application.UseCases.Invoices.Delete;
using BarberBoss.Application.UseCases.Invoices.GetAll;
using BarberBoss.Application.UseCases.Invoices.GetById;
using BarberBoss.Application.UseCases.Invoices.Register;
using BarberBoss.Application.UseCases.Invoices.Update;
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
            services.AddScoped<IDeleteInvoiceUseCase, DeleteInvoiceUseCase>();

            services.AddScoped<IUpdateInvoiceUseCase, UpdateInvoiceUseCase>();


            services.AddScoped<IGetAllInvoiceUseCase, GetAllInvoiceUseCase>();
            services.AddScoped<IGetByIdInvoiceUseCase, GetByIdInvoiceUseCase>();

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
