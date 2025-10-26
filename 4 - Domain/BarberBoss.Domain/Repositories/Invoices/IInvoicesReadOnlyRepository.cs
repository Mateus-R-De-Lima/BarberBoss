using BarberBoss.Domain.Entities;

namespace BarberBoss.Domain.Repositories.Invoices
{
    public interface IInvoicesReadOnlyRepository
    {
        Task<List<Invoice>> GetAll();
        Task<Invoice?> GetById(Guid id);

        Task<List<Invoice>> FilterByMonth(DateOnly date);
    }
}
