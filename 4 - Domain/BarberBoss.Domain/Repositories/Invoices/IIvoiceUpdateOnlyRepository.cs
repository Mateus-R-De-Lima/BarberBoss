using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories.Invoices
{
    public interface IIvoiceUpdateOnlyRepository
    {
        void Update(Invoice expense);

        Task<Invoice?> GetById(Guid id);
    }
}
