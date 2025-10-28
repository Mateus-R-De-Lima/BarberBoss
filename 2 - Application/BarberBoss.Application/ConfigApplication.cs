using BarberBoss.Application.AutoMapper;
using BarberBoss.Application.UseCases.Billing.Delete;
using BarberBoss.Application.UseCases.Billing.GetAll;
using BarberBoss.Application.UseCases.Billing.GetById;
using BarberBoss.Application.UseCases.Billing.Register;
using BarberBoss.Application.UseCases.Billing.Update;
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
            services.AddScoped<IRegisterBillingUseCase, RegisterBillingUseCase>();

            services.AddScoped<IDeleteBillingUseCase, DeleteBillingUseCase>();

            services.AddScoped<IUpdateBillingUseCase, UpdateBillingUseCase>();


            services.AddScoped<IGetAllBillingsUseCase, GetAllBillingsUseCase>();
            services.AddScoped<IGetByIdBillingUseCase, GetByIdBillingUseCase>();
            services.AddScoped<IGetAllWithFiltersUseCase, GetAllWithFiltersUseCase>();

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
