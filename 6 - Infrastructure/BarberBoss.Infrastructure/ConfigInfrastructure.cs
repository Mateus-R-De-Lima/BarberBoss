using BarberBoss.Domain;
using BarberBoss.Domain.Repositories.Billings;
using BarberBoss.Domain.Repositories.User;
using BarberBoss.Infrastructure.DataAccess;
using BarberBoss.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BarberBoss.Infrastructure
{
    public static class ConfigInfrastructure
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);

            AddDbContext(services, configuration);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBillingsWriteOnlyRepository, BillingsRepository>();
            services.AddScoped<IBillingsReadOnlyRepository, BillingsRepository>();
            services.AddScoped<IBillingUpdateOnlyRepository, BillingsRepository>();


            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserUpdateOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();


        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");

            var version = new Version(8, 0, 43);
            var serverVersion = new MySqlServerVersion(version);

            services.AddDbContext<BillingDbContext>(config => config.UseMySql(connectionString, serverVersion));
        }

    }
}
