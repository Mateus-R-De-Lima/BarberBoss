using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories.Billings
{
    public interface IBillingUpdateOnlyRepository
    {
        void Update(Billing expense);

        Task<Billing?> GetById(Guid id);
    }
}
