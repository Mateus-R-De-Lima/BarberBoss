using BarberBoss.Application.AutoMapper;
using BarberBoss.Application.Reports.Excel;
using BarberBoss.Application.UseCases.Billing.Delete;
using BarberBoss.Application.UseCases.Billing.GetAll;
using BarberBoss.Application.UseCases.Billing.GetById;
using BarberBoss.Application.UseCases.Billing.Register;
using BarberBoss.Application.UseCases.Billing.Update;
using BarberBoss.Application.UseCases.LoggerUser;
using BarberBoss.Application.UseCases.User.Delete;
using BarberBoss.Application.UseCases.User.DoLogin;
using BarberBoss.Application.UseCases.User.GetProfile;
using BarberBoss.Application.UseCases.User.Register;
using BarberBoss.Application.UseCases.User.UpdateProfile;
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

            services.AddScoped<IGenerateBillingsReportExcelUseCase, GenerateBillingsReportExcelUseCase>();


            services.AddScoped<IGetAllBillingsUseCase, GetAllBillingsUseCase>();
            services.AddScoped<IGetByIdBillingUseCase, GetByIdBillingUseCase>();
            services.AddScoped<IGetAllWithFiltersUseCase, GetAllWithFiltersUseCase>();


            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddScoped<IGetUserProfileUseCase, GetUserProfileUseCase>();
            services.AddScoped<IUpdateUserProfileUseCase, UpdateUserProfileUseCase>();
            services.AddScoped<IDeleteProfileUserUseCase, DeleteProfileUserUseCase>();

            services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();

            services.AddScoped<ILoggerUser, LoggerUser>();

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
