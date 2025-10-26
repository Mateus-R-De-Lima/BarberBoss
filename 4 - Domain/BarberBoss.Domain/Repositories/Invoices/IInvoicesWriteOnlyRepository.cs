using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories.Invoices
{
    public interface IInvoicesWriteOnlyRepository
    {
        Task Add(Invoice invoice);

        Task<bool> Delete(Guid id);
    }
}
