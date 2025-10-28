using BarberBoss.Communication.Response;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Filter;

namespace BarberBoss.Domain.Repositories.Billings
{
    public interface IBillingsReadOnlyRepository
    {
        Task<List<Billing>> GetAll();
        Task<Billing?> GetById(Guid id);

        Task<List<Billing>> FilterByMonth(DateOnly date);

        Task<PagedResult<Billing?>> GetAllWithFilters(BillingFilter filter);
    }
}
